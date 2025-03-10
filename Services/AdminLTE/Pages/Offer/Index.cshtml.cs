using AdminLTE.Services;
using Authentication.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Application.HolidayAppService.Dtos;
using Offer.Application.OfferAppService.Dtos;
using Offer.Data.DbContext;
using Offer.Domain.Models;
using System.Collections.Generic;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AdminLTE.Pages.Offer
{
    public class OfferModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _userHttpClient;

        public OfferModel(HttpClientService httpClientService, HttpClientService httpClientServiceUser)
        {

            _httpClient = httpClientService.GetHttpClient("7099");
            _userHttpClient = httpClientServiceUser.GetHttpClient("7182");

        }


        [BindProperty(SupportsGet = true)] 
        public string SelectedType { get; set; }

        [BindProperty(SupportsGet = true)] 
        public string SelectedUser { get; set; }

        [BindProperty]
        public List<OfferGetDto> Offers { get; set; } = new List<OfferGetDto>();
        [BindProperty]
        public List<FlightOfferGetDto> FlightOffers { get; set; } = new List<FlightOfferGetDto>();
        [BindProperty]
        public List<HolidayGetDto> HolidayOffers { get; set; } = new List<HolidayGetDto>();


        [BindProperty]
        public List<AuthenticationGetDto> Users { get; set; } = new List<AuthenticationGetDto>();


        public async Task<IActionResult> OnGetAsync(int? Id, string? name, DateTime? EndDate, string? SelectedType, string? SelectedUser)
        
        {
            try
            {
                string apiUrl = "/FlightOffer";

                string offerapiUrl = "/Offer";

                string apiUrlholiday = "/HolidayOffer";
                //string apiUrl2 = "/ChamMilesOffer"

                if (Id.HasValue)
                {
                    apiUrl += $"/{Id.Value}";
                    apiUrlholiday += $"/{Id.Value}"; 
                    //apiUrl2 += $"/{Id.Value}"; 

                }
                if (!string.IsNullOrEmpty(name))
                {
                    offerapiUrl += $"?filters=Name@={name}";
                }

                if (EndDate.HasValue)
                {
                    apiUrl += $"?filters=EndDate@={EndDate}";
                }

                var users = await _userHttpClient.GetAsync("/api/Authentication/get-all-users");
                
                var offers = await _httpClient.GetAsync(offerapiUrl);

                // Fetch data from the API
                var response = await _httpClient.GetAsync(apiUrl);

                var responseholiday = await _httpClient.GetAsync(apiUrlholiday); 
                //var response2 = await _httpClient.GetAsync(apiUrl2); 


                if (response.IsSuccessStatusCode  && offers.IsSuccessStatusCode && users.IsSuccessStatusCode && responseholiday.IsSuccessStatusCode)//&&response2.IsSuccessStatusCode )
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var holiday_content = await responseholiday.Content.ReadAsStringAsync();
                    //var content2 = await response2.Content.ReadAsStringAsync();

                    var offers_content = await offers.Content.ReadAsStringAsync();

                    var user_content = await users.Content.ReadAsStringAsync();

                    Offers = JsonSerializer.Deserialize<List<OfferGetDto>>(offers_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    Users = JsonSerializer.Deserialize<List<AuthenticationGetDto>>(user_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                    if (!string.IsNullOrEmpty(SelectedType) && SelectedType != "All")
                    {
                        Offers = Offers.Where(o => o.Type == SelectedType).ToList();
                    }

                    // Filter by selected user
                    if (!string.IsNullOrEmpty(SelectedUser) && SelectedUser != "AllUsers")
                    {
                        var selectedUserName = SelectedUser.Split(' ');
                        var firstName = selectedUserName[0];
                        var lastName = selectedUserName.Length > 1 ? string.Join(" ", selectedUserName.Skip(1)) : "";


                        // Assuming Users is a list of AuthenticationGetDto with FirstName and LastName properties
                        var selectedUser = Users.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName);

                        if (selectedUser != null)
                        {
                            // Assuming Offers have a UserId or similar property to filter by
                            Offers = Offers.Where(o => o.CreatedBy == selectedUser.Code).ToList();
                        }
                    }

                    if (Id.HasValue)
                    {

                        // If searching by ID, deserialize a single object and add it to the list
                        var singleFlightOffer = JsonSerializer.Deserialize<FlightOfferGetDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        FlightOffers = new List<FlightOfferGetDto> { singleFlightOffer };

                        var singleHolidayOffer = JsonSerializer.Deserialize<HolidayGetDto>(holiday_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        HolidayOffers = new List<HolidayGetDto> { singleHolidayOffer };

                        //var singleOffer = JsonSerializer.Deserialize<>(content2, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        //Offers = new List<> { singleOffer };

                    }
                    else
                    {

                        FlightOffers = JsonSerializer.Deserialize<List<FlightOfferGetDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        FlightOffers = GetFlightOffersByOfferIds(Offers, FlightOffers);
                        
                        HolidayOffers = JsonSerializer.Deserialize<List<HolidayGetDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        HolidayOffers = GetHolidayOffersByOfferIds(Offers, HolidayOffers);


                        //ChamMilesOffers = JsonSerializer.Deserialize<List<FlightOfferGetDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
        public OfferGetDto GetOfferById(int offerId)
        {
            return Offers.FirstOrDefault(o => o.Id == offerId);
        }
        public List<FlightOfferGetDto> GetFlightOffersByOfferIds(List<OfferGetDto> offers, List<FlightOfferGetDto> flightOffers)
        {
            // Get a list of all OfferIds from the Offers list
            var offerIds = offers.Select(o => o.Id).ToList();

            // Filter the FlightOffers list by matching OfferId
            var filteredFlightOffers = flightOffers.Where(f => offerIds.Contains(f.OfferID)).ToList();

            return filteredFlightOffers;
        }
        public List<HolidayGetDto> GetHolidayOffersByOfferIds(List<OfferGetDto> offers, List<HolidayGetDto> holidayOffers)
        {
            // Get a list of all OfferIds from the Offers list
            var offerIds = offers.Select(o => o.Id).ToList();

            // Filter the FlightOffers list by matching OfferId
            var filteredHolidayOffers = holidayOffers.Where(f => offerIds.Contains(f.OfferID)).ToList();

            return filteredHolidayOffers;
        }


    }
}
