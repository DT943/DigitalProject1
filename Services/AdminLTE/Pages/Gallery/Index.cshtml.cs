using Authentication.Application.Dtos;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.GalleryAppService.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Application.HolidayAppService.Dtos;
using Offer.Application.OfferAppService.Dtos;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AdminLTE.Pages.Gallery
{
    public class GalleryModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public GalleryModel(HttpClient httpClient)
        {

            _httpClient = httpClient;
            //_httpClient = new HttpClient(httpClientHandler);
            //_httpClient.BaseAddress = new Uri("https://92.112.184.210:7099");
            _httpClient.BaseAddress = new Uri("https://localhost:7181");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ0YXJlazNzaGVpa2hhbGFyZCIsImp0aSI6IjlhMDU3YmJlLWIyOTQtNGJmMS1hNDFmLTZlMWI4ZmU2YmNmYSIsImVtYWlsIjoidGFyZWszLmRvZUBleGFtcGxlLmNvbSIsInVzZXJDb2RlIjoiQ3VzdG9tZXItNWI5MTA1ODc3ZGRmNDY1YjljMjJiZjZjNmZmOGJjOWMiLCJyb2xlcyI6IkN1c3RvbWVyIiwiZXhwIjoxNzQxMzMxMTc1LCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VyIn0.0aY7hMho93ZKH0pCof5AiL81sY_zWvXorP16ggPUFEU");

        }

        [BindProperty]
        public List<GalleryGetDto> Galleries { get; set; } = new List<GalleryGetDto>();

        public async Task<IActionResult> OnGetAsync(int? Id, string? name)
        {
            try
            {
                string galleryApiUrl = "/Gallery";

                if (Id.HasValue)
                {
                    galleryApiUrl += $"/{Id.Value}";

                }
                if (!string.IsNullOrEmpty(name))
                {
                    galleryApiUrl += $"?filters=Name@={name}";
                }

                var galleries = await _httpClient.GetAsync(galleryApiUrl);


                if (galleries.IsSuccessStatusCode)
                { 
                    var gallery_content = await galleries.Content.ReadAsStringAsync();


                    Galleries = JsonSerializer.Deserialize<List<GalleryGetDto>>(gallery_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                       
                    if (Id.HasValue)
                    {

                        var singleGallery = JsonSerializer.Deserialize<GalleryGetDto>(gallery_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        Galleries = new List<GalleryGetDto> { singleGallery };

                    }
                    else
                    {
                        Galleries = JsonSerializer.Deserialize<List<GalleryGetDto>>(gallery_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
