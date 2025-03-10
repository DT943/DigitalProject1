using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using Offer.Application.FlightOfferAppService.Dtos;
using AdminLTE.Services;

namespace AdminLTE.Pages.Offer
{
    public class CreateFlightModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateFlightModel(HttpClientService httpClientService)
        {
            _httpClient = httpClientService.GetHttpClient("7099");
        }

        [BindProperty]
        public FlightOfferCreateDto FlightOffer { get; set; } = new FlightOfferCreateDto();

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
            var json = JsonSerializer.Serialize(FlightOffer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send a POST request to the FlightOfferController API
            var response = await _httpClient.PostAsync("/FlightOffer", content);

            if (response.IsSuccessStatusCode)
            {
                // Redirect to a success page or another action
				return RedirectToPage("/Offer/Index");
			}
			else
            {
                // Handle API errors
                ModelState.AddModelError(string.Empty, "An error occurred while creating the flight offer.");
                return Page();
            }
        }
    }

}

