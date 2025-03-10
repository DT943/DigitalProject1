using Gallery.Application.FileAppservice.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Gallery.Application.GalleryAppService.Dtos;
using AdminLTE.Services;

namespace AdminLTE.Pages.Gallery
{
    public class CreateGalleryModel : PageModel
    {

        private readonly HttpClient _httpClient;

        public CreateGalleryModel(HttpClientService httpClientService)
        {
            _httpClient = httpClientService.GetHttpClient("7181");
        }

        [BindProperty]
        public GalleryCreateDto Gallery { get; set; } = new GalleryCreateDto();

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
            var json = JsonSerializer.Serialize(Gallery);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a POST request to the FlightOfferController API
            var response = await _httpClient.PostAsync("/Gallery", content);

            if (response.IsSuccessStatusCode)
            {
                // Redirect to a success page or another action
                return RedirectToPage("/Gallery/Index");
            }
            else
            {
                // Handle API errors
                ModelState.AddModelError(string.Empty, "An error occurred while creating the gallery.");
                return Page();
            }
        }
    }
}
