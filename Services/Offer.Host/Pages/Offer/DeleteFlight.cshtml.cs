using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace Offer.Host.Pages.Offer
{
    public class DeleteFlightModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public DeleteFlightModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7099");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ0YXJlazNzaGVpa2hhbGFyZCIsImp0aSI6ImE1YzhiYmYyLWM0NzItNGNjMS1hYzUwLTcwN2NjZThmN2RkNCIsImVtYWlsIjoidGFyZWszLmRvZUBleGFtcGxlLmNvbSIsInVzZXJDb2RlIjoiQ3VzdG9tZXItNWI5MTA1ODc3ZGRmNDY1YjljMjJiZjZjNmZmOGJjOWMiLCJyb2xlcyI6IkN1c3RvbWVyIiwiZXhwIjoxNzQxMDg0NjMyLCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VyIn0.AyigZyYSpAA9pbBUcHWT99ol7TlPk5I9f7VywhiSZsM");
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/FlightOffer/{id}");

            if (response.IsSuccessStatusCode)
            {
                return Page();
            }
            
            return BadRequest("Failed to delete the flight.");

        }

    }
}
