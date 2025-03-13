using AdminLTE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Application.OfferAppService.Dtos;
using Offer.Domain.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdminLTE.Pages.Offer
{
    public class UpdateFlightModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public UpdateFlightModel(HttpClientService httpClientService)
        {
            _httpClient = httpClientService.GetHttpClient("7099");

        }

        [BindProperty]
        public FlightOfferUpdateDto FlightOffer { get; set; } = new FlightOfferUpdateDto();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/FlightOffer/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }


            var content = await response.Content.ReadAsStringAsync();
            FlightOffer = JsonSerializer.Deserialize<FlightOfferUpdateDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return Page();
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var json = JsonSerializer.Serialize(FlightOffer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/FlightOffer", content);

            if (response.IsSuccessStatusCode)
            {
				return RedirectToPage("/Offer/Index");
			}
			else
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the flight offer.");
                return Page();
            }
        }
    }
}
