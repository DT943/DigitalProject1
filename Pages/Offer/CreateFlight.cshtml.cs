using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Offer.Application.FlightOfferAppService.Dtos;
using System.Text.Json;
using System.Text;

namespace Offer.Host.Pages.Offer
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7099"); 
        }

        [BindProperty]
        public FlightOfferCreateDto FlightOffer { get; set; }

        public IActionResult OnGet()
        {
            // Initialize default values if needed
            FlightOffer = new FlightOfferCreateDto();
            return Page();
        }

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
                return RedirectToPage("./Index");
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

