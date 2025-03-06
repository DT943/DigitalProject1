using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Offer.Application.FlightOfferAppService.Dtos;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using Gallery.Application.FileAppservice.Dtos;

namespace AdminLTE.Pages.Gallery.File
{
    public class CreateFileModel : PageModel
    {
            private readonly HttpClient _httpClient;

            public CreateFileModel(HttpClient httpClient)
            {
                _httpClient = httpClient;
                _httpClient.BaseAddress = new Uri("https://localhost:7181");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ0YXJlazNzaGVpa2hhbGFyZCIsImp0aSI6ImFhM2M4OWExLTE4NmQtNDI3Zi1hODI0LTY3NThlMjAzMGRiNCIsImVtYWlsIjoidGFyZWszLmRvZUBleGFtcGxlLmNvbSIsInVzZXJDb2RlIjoiQ3VzdG9tZXItNWI5MTA1ODc3ZGRmNDY1YjljMjJiZjZjNmZmOGJjOWMiLCJyb2xlcyI6IkN1c3RvbWVyIiwiZXhwIjoxNzQxMzQ2NTI3LCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VyIn0.yb2LYTORv6ThGpRNbjvs4biK5JYm4P8NWOwVnlaOpUc");
            }

            [BindProperty]
            public FileCreateDto File { get; set; } = new FileCreateDto();

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
                var json = JsonSerializer.Serialize(File);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Send a POST request to the FlightOfferController API
                var response = await _httpClient.PostAsync("/File", content);

                if (response.IsSuccessStatusCode)
                {
                    // Redirect to a success page or another action
                    return Page();
                }
                else
                {
                    // Handle API errors
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the file.");
                    return Page();
                }
            }
        }

    }
