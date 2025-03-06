using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.GalleryAppService.Dtos;
using Gallery.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AdminLTE.Pages.Gallery.File
{
    public class FileModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public FileModel(HttpClient httpClient)
        {

            _httpClient = httpClient;
            //_httpClient = new HttpClient(httpClientHandler);
            //_httpClient.BaseAddress = new Uri("https://92.112.184.210:7099");
            _httpClient.BaseAddress = new Uri("https://localhost:7181");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ0YXJlazNzaGVpa2hhbGFyZCIsImp0aSI6ImFhM2M4OWExLTE4NmQtNDI3Zi1hODI0LTY3NThlMjAzMGRiNCIsImVtYWlsIjoidGFyZWszLmRvZUBleGFtcGxlLmNvbSIsInVzZXJDb2RlIjoiQ3VzdG9tZXItNWI5MTA1ODc3ZGRmNDY1YjljMjJiZjZjNmZmOGJjOWMiLCJyb2xlcyI6IkN1c3RvbWVyIiwiZXhwIjoxNzQxMzQ2NTI3LCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VyIn0.yb2LYTORv6ThGpRNbjvs4biK5JYm4P8NWOwVnlaOpUc");

        }

        [BindProperty]
        public List<FileGetDto> Files { get; set; } = new List<FileGetDto>();

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }
        


        /*
            public async Task<IActionResult> OnGetAsync(int? Id, int GalleryId)
        {
            try
            {

                string fileApiUrl = "/File";

                if (Id.HasValue)
                {
                    fileApiUrl += $"/{Id.Value}";

                }

                var files = await _httpClient.GetAsync(fileApiUrl);


                if (files.IsSuccessStatusCode)
                {

                    var file_content = await files.Content.ReadAsStringAsync();


                    if (Id.HasValue)
                    {

                        var singleFile = JsonSerializer.Deserialize<FileGetDto>(file_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        Files = new List<FileGetDto> { singleFile };

                    }
                    else
                    {

                        Files = JsonSerializer.Deserialize<List<FileGetDto>>(file_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        Files = Files.Where(f => f.GalleryId == GalleryId).ToList();

                    }
                }
                else
                {
                    // Handle API errors
                    ModelState.AddModelError(string.Empty, "An error occurred while fetching offers.");
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request exceptions
                ModelState.AddModelError(string.Empty, "Unable to connect to the server. Please try again later.");
            }

            return Page();
        }
       */

    }
}
