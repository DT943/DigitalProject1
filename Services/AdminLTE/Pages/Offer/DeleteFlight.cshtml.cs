using AdminLTE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace AdminLTE.Pages.Offer
{
    public class DeleteFlightModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public DeleteFlightModel(HttpClientService httpClientService)
        {
            _httpClient = httpClientService.GetHttpClient("7099");
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/FlightOffer/{id}");

            if (response.IsSuccessStatusCode)
            {
				return RedirectToPage("/Offer/Index");
			}

			return BadRequest("Failed to delete the flight.");

        }

    }
}
