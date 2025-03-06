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

        public UpdateFlightModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7099");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ0YXJlazNzaGVpa2hhbGFyZCIsImp0aSI6ImFhM2M4OWExLTE4NmQtNDI3Zi1hODI0LTY3NThlMjAzMGRiNCIsImVtYWlsIjoidGFyZWszLmRvZUBleGFtcGxlLmNvbSIsInVzZXJDb2RlIjoiQ3VzdG9tZXItNWI5MTA1ODc3ZGRmNDY1YjljMjJiZjZjNmZmOGJjOWMiLCJyb2xlcyI6IkN1c3RvbWVyIiwiZXhwIjoxNzQxMzQ2NTI3LCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VyIn0.yb2LYTORv6ThGpRNbjvs4biK5JYm4P8NWOwVnlaOpUc");

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
                return Page();
            }
            else
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the flight offer.");
                return Page();
            }
        }
    }
}
