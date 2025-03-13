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

            StringUtility.ConvertStringsToLowercase(Gallery);

            // Serialize the FlightOffer object to JSON
            var json = JsonSerializer.Serialize(Gallery);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a POST request to the FlightOfferController API
            var response = await _httpClient.PostAsync("/Gallery", content);

            var errorResponse = await response.Content.ReadAsStringAsync(); // Read response as string

            if (response.IsSuccessStatusCode)
            {
                // Redirect to a success page or another action
                return RedirectToPage("/Gallery/Index");
            }
            else
            {
                try
                {
                    var errorDetails = JsonSerializer.Deserialize<ApiErrorResponse>(errorResponse,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (errorDetails?.Error?.Data != null)
                    {
                        foreach (var error in errorDetails.Error.Data)
                        {
                            var fieldKey = $"Gallery.{char.ToUpper(error.Key[0]) + error.Key.Substring(1)}"; // Ensure proper casing

                            foreach (var errorMessage in error.Value)
                            {
                                ModelState.AddModelError(fieldKey, errorMessage);
                            }
                        }
                    }

                    ModelState.AddModelError(string.Empty, errorDetails?.Error?.Message ?? "An error occurred.");
                }
                catch (JsonException ex)
                {
                    ModelState.AddModelError(string.Empty, "Error parsing API response.");
                    Console.WriteLine($"JSON Parsing Error: {ex.Message}");
                    Console.WriteLine($"Raw API Response: {errorResponse}");
                }

                return Page();
            }
        }
    }
}
