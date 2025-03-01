using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Application.OfferAppService.Dtos;
using Offer.Data.DbContext;
using Offer.Domain.Models;
using System.Text.Json;

namespace Offer.Host.Pages.Offer
{
    public class OfferModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public OfferModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7099"); 
        }

        [BindProperty]
        public List<OfferGetDto> Offers { get; set; } = new List<OfferGetDto>();
        [BindProperty]
        public List<FlightOfferGetDto> FlightOffers { get; set; } = new List<FlightOfferGetDto>();

        [BindProperty]
        public List<> Users { get; set; } = new List<>();


        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            try
            {
                string apiUrl = "/FlightOffer";

                if (Id.HasValue)
                {
                    apiUrl += $"/{Id.Value}"; 
                }

                //FetchUser 
                var users = await _httpClient.GetAsync("/GetAllUser");
                var offers = await _httpClient.GetAsync("/Offer");

                // Fetch data from the API
                var response = await _httpClient.GetAsync(apiUrl); 

                if (response.IsSuccessStatusCode && users.IsSuccessStatusCode)
                {
                    // Deserialize the response content into a list of FlightOfferGetDto
                    var content = await response.Content.ReadAsStringAsync();

                    var user_content = await users.Content.ReadAsStringAsync();

                    var offers_content = await offers.Content.ReadAsStringAsync();
                    if (Id.HasValue)
                    {
                        // If searching by ID, deserialize a single object and add it to the list
                        var singleOffer = JsonSerializer.Deserialize<OfferGetDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        Offers = new List<OfferGetDto> { singleOffer };
                    }
                    else
                    {
                        Users = JsonSerializer.Deserialize<List<>>(user_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        // Deserialize as a list for normal fetch
                        Offers = JsonSerializer.Deserialize<List<OfferGetDto>>(offers_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        
                        FlightOffers = JsonSerializer.Deserialize<List<FlightOfferGetDto>>(offers_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

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
