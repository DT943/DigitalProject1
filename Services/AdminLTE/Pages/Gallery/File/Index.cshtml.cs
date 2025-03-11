using AdminLTE.Services;
using Authentication.Application.Dtos;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.GalleryAppService.Dtos;
using Gallery.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AdminLTE.Pages.Gallery.File
{
    public class FileModel : PageModel
    {
        private readonly HttpClient _httpClient;


        public FileModel(HttpClientService httpClientService)
        {
            // Retrieve the configured HttpClient from the HttpClientService
            _httpClient = httpClientService.GetHttpClient("7181");

        }
        [BindProperty(SupportsGet = true)]
        public string SelectedUser { get; set; }

        [BindProperty]
        public List<AuthenticationGetDto> Users { get; set; } = new List<AuthenticationGetDto>();

        [BindProperty(SupportsGet = true)]
        public int GalleryId { get; set; }

        [BindProperty]
        public List<FileGetDto> Files { get; set; } = new List<FileGetDto>();

        public async Task<IActionResult> OnGetAsync(int? Id, int galleryId)
        {
            try
            {
                GalleryId = galleryId;

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

                        Files = Files.Where(f => f.GalleryId == galleryId).ToList();

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
    } 
}

