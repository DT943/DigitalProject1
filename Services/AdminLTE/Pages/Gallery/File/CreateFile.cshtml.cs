using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Gallery.Application.FileAppservice.Dtos;
using AdminLTE.Services;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Net.Http;
using System.IO;
using Gallery.Domain.Models;

namespace AdminLTE.Pages.Gallery.File
{
    public class CreateFileModel : PageModel
    {
        private readonly HttpClient _httpClient;

            public CreateFileModel(HttpClient httpClient)
            {
                _httpClient = httpClient;
                _httpClient.BaseAddress = new Uri("https://localhost:7181");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ0YXJlazNzaGVpa2hhbGFyZCIsImp0aSI6IjIyNjIxZDJjLTM4MTEtNDQ2Yi1iZGI2LTMzMDFiMjU0YTIwYyIsImVtYWlsIjoidGFyZWszLmRvZUBleGFtcGxlLmNvbSIsInVzZXJDb2RlIjoiQ3VzdG9tZXItNWI5MTA1ODc3ZGRmNDY1YjljMjJiZjZjNmZmOGJjOWMiLCJyb2xlcyI6IkN1c3RvbWVyIiwiZXhwIjoxNzQxMjE3Mjc1LCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VyIn0.nlMchLfRMwj7vtcgIE3JZCnAzNR-jEuWdLU7LHqgwaU");
            }

            [BindProperty]
            public FileCreateDto File { get; set; } = new FileCreateDto();

            public IActionResult OnGet()
            {
                return Page();
            }
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    // If validation fails, return to the form with errors
                    return Page();
                }

                // Serialize the FlightOffer object to JSON
                var json = JsonSerializer.Serialize(File);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send a POST request to the FlightOfferController API
                var response = await _httpClient.PostAsync("/File", content);

                if (response.IsSuccessStatusCode)
                {
                    // Redirect to a success page or another action
                    return Page();
                }
                else
                {
                    // Handle API errors
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the file.");
                    return Page();
                }
            }
        }

        [BindProperty]
        public FileCreateDto File { get; set; } = new FileCreateDto();
        [BindProperty]
        public IFormFile UploadedFile { get; set; }
        [BindProperty(SupportsGet = true)]
        public int GalleryId { get; set; }

        public async Task<IActionResult> OnGetAsync(int galleryId)
        {
            GalleryId = galleryId;
            return Page();
        }
        public (int Width, int Height) GetJpegDimensions(Stream stream)
        {
            using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
            {
                // JPEG files start with the marker 0xFFD8
                if (reader.ReadUInt16() != 0xFFD8)
                    throw new ArgumentException("Not a valid JPEG file.");

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    // Read the marker (2 bytes)
                    ushort marker = reader.ReadUInt16();

                    // Check if it's a Start of Frame (SOF) marker
                    if (marker >= 0xFFC0 && marker <= 0xFFCF && marker != 0xFFC4 && marker != 0xFFC8)
                    {
                        // Skip the length (2 bytes)
                        reader.ReadUInt16();

                        // Read the height (2 bytes) and width (2 bytes)
                        int height = reader.ReadUInt16();
                        int width = reader.ReadUInt16();

                        return (width, height);
                    }
                    else
                    {
                        // Skip the length of this segment
                        ushort length = reader.ReadUInt16();
                        reader.BaseStream.Seek(length - 2, SeekOrigin.Current);
                    }
                }
            }

            throw new ArgumentException("Could not find image dimensions in JPEG file.");
        }
        public (int Width, int Height) GetPngDimensions(Stream stream)
        {
            using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
            {
                // PNG files start with the signature 0x89504E470D0A1A0A
                if (reader.ReadUInt64() != 0x89504E470D0A1A0A)
                    throw new ArgumentException("Not a valid PNG file.");

                // Read the IHDR chunk
                uint chunkLength = reader.ReadUInt32();
                if (Encoding.ASCII.GetString(reader.ReadBytes(4)) != "IHDR")
                    throw new ArgumentException("Could not find IHDR chunk in PNG file.");

                // Read width and height (4 bytes each)
                int width = reader.ReadInt32();
                int height = reader.ReadInt32();

                return (width, height);
            }
        }
        public TimeSpan GetMp4Duration(Stream stream)
        {
            using (var reader = new BinaryReader(stream, Encoding.UTF8, true))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    long atomSize = reader.ReadUInt32();
                    string atomType = Encoding.ASCII.GetString(reader.ReadBytes(4));

                    if (atomType == "moov" || atomType == "trak")
                    {
                        // Look for 'mvhd' or 'tkhd' atoms
                        long endPosition = reader.BaseStream.Position + atomSize - 8;
                        while (reader.BaseStream.Position < endPosition)
                        {
                            long subAtomSize = reader.ReadUInt32();
                            string subAtomType = Encoding.ASCII.GetString(reader.ReadBytes(4));

                            if (subAtomType == "mvhd")
                            {
                                // Skip version and flags (4 bytes)
                                reader.BaseStream.Seek(4, SeekOrigin.Current);

                                // Read timescale (4 bytes) and duration (4 bytes)
                                uint timescale = reader.ReadUInt32();
                                uint duration = reader.ReadUInt32();

                                return TimeSpan.FromSeconds((double)duration / timescale);
                            }
                            else if (subAtomType == "tkhd")
                            {
                                // Skip version and flags (4 bytes)
                                reader.BaseStream.Seek(4, SeekOrigin.Current);

                                // Read duration (4 bytes)
                                uint duration = reader.ReadUInt32();

                                return TimeSpan.FromSeconds(duration);
                            }
                            else
                            {
                                // Skip to the next atom
                                reader.BaseStream.Seek(subAtomSize - 8, SeekOrigin.Current);
                            }
                        }
                    }
                    else
                    {
                        // Skip to the next atom
                        reader.BaseStream.Seek(atomSize - 8, SeekOrigin.Current);
                    }
                }
            }

            throw new ArgumentException("Could not find duration in MP4 file.");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            // Check if a file is uploaded
            if (UploadedFile == null || UploadedFile.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Please select a file to upload.");
                return Page();
            }

            // Step 1: Upload the file to the first API
            var fileContent = new StreamContent(UploadedFile.OpenReadStream());
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(UploadedFile.ContentType);

            var formData = new MultipartFormDataContent();
            formData.Add(fileContent, "file", UploadedFile.FileName);

            var uploadResponse = await _httpClient.PostAsync("/File/UploadFile", formData);

            if (!uploadResponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Failed to upload the file.");
                return Page();
            }

            // Get the file path from the upload response
            var filePath = await uploadResponse.Content.ReadAsStringAsync();

            // Step 2: Retrieve file details from the second API
            var content = new StringContent(filePath, Encoding.UTF8, "application/problem+json");

            var getFileResponse = await _httpClient.PostAsync("/File/GetFile", content);

            if (!getFileResponse.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Failed to retrieve file details.");
                return Page();
            }

            // Step 3: Process the file details returned from the API
            var fileDetailsJson = await getFileResponse.Content.ReadAsStringAsync();

            using var fileDetailsDoc = JsonDocument.Parse(fileDetailsJson);
            var fileDetails = fileDetailsDoc.RootElement;

            // Extract the necessary file details from the response
            var filePhysicalPath = fileDetails.GetProperty("filePhysicalPath");
            var fileUrlPath = fileDetails.GetProperty("fileUrlPath").GetString();

            var mimeType = filePhysicalPath.GetProperty("contentType").GetString();
            var fileType = mimeType.Split('/')[0];
            var galleryId = GalleryId;
            var fileName = Path.GetFileName(fileUrlPath);
            
            int? imageWidth = null;
            int? imageHeight = null;
            TimeSpan? mediaDuration = null;

            // Process image files
            if (fileType == "image")
            {
                if (mimeType == "image/jpeg")
                {
                    //Lubna
                    (imageWidth, imageHeight) = (0,0);
                }
                else if (mimeType == "image/png")
                {
                    //Lubna
                    (imageWidth, imageHeight) = (0, 0);
                }
            }
            // Process video or audio files
            else if (fileType == "video" || fileType == "audio")
            {
                if (mimeType == "video/mp4")
                {
                    mediaDuration = new TimeSpan(1, 2, 30, 15);       
                }
            }
            return RedirectToPage("/Gallery/File/CreateDetailFile", new
            {
                FileName = fileName,
                FilePath = fileUrlPath,
                FileSize = UploadedFile.Length,
                MimeType = mimeType,
                FileType = fileType,
                GalleryId = GalleryId.ToString(),
                ImageWidth = imageWidth, 
                ImageHeight = imageHeight, 
                Lenght = mediaDuration?.ToString("c")
            });

        }
    }
}
