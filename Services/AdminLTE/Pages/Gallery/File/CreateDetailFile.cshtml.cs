using AdminLTE.Services;
using Gallery.Application.FileAppservice.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text;
using Gallery.Domain.Models;

namespace AdminLTE.Pages.Gallery.File
{
    public class CreateDetailFileModel : PageModel
    {
            private readonly HttpClient _httpClient;

            public CreateDetailFileModel(HttpClientService httpClientService)
            {
                _httpClient = httpClientService.GetHttpClient("7181");
            }

            [BindProperty]
            public FileCreateDto File { get; set; } = new FileCreateDto();

            [BindProperty(SupportsGet = true)]
            public string FileName { get; set; }
            [BindProperty(SupportsGet = true)]
            public string FilePath { get; set; }
            [BindProperty(SupportsGet = true)]
            public long FileSize { get; set; }
            [BindProperty(SupportsGet = true)]
            public string MimeType { get; set; }
            [BindProperty(SupportsGet = true)]
            public string FileType { get; set; }
            [BindProperty(SupportsGet = true)]
            public int GalleryId { get; set; }
            [BindProperty(SupportsGet = true)]
            public int ImageWidth { get; set; }
            [BindProperty(SupportsGet = true)]
            public int ImageHeight { get; set; }
            [BindProperty(SupportsGet = true)]
            public  TimeSpan  Lenght { get; set; }


            public void OnGet(int galleryId)
            {
                File.Name = FileName;
                File.Path = FilePath;
                File.Size = FileSize;
                File.MimeType = MimeType.ToString();
                File.FileType = FileType;
                File.ImageWidth = ImageWidth;
                File.ImageHeight = ImageHeight;
                File.Duration = Lenght;
                File.GalleryId = galleryId;
            }

            public async Task<IActionResult> OnPostAsync()
            {

                var json = JsonSerializer.Serialize(File);
                var detailsContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/File", detailsContent);

                if (response.IsSuccessStatusCode)
                {
				    return RedirectToPage("/Gallery/File/Index", new { galleryId = File.GalleryId });
			    }
			    else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the file.");
                    return Page();
                }
            }
        
    }
}
