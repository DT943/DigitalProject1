using AdminLTE.Services;
using Authentication.Application.Dtos;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.GalleryAppService.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Application.HolidayAppService.Dtos;
using Offer.Application.OfferAppService.Dtos;
using Offer.Domain.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AdminLTE.Pages.Gallery
{
    public class GalleryModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _userHttpClient;

        public GalleryModel(HttpClientService httpClientService)
        {

            _httpClient = httpClientService.GetHttpClient("7181");
            _userHttpClient = httpClientService.GetHttpClient("7182");

        }

        [BindProperty(SupportsGet = true)]
        public string SelectedUser { get; set; }

        [BindProperty]
        public List<GalleryGetDto> Galleries { get; set; } = new List<GalleryGetDto>();

        [BindProperty]
        public List<AuthenticationGetDto> Users { get; set; } = new List<AuthenticationGetDto>();


        public async Task<IActionResult> OnGetAsync(int? Id, string? name)
        {
            try
            {
                string galleryApiUrl = "/Gallery";

                if (Id.HasValue)
                {
                    galleryApiUrl += $"/{Id.Value}";

                }
                if (!string.IsNullOrEmpty(name))
                {
                    galleryApiUrl += $"?filters=Name@={name}";
                }

                var galleries = await _httpClient.GetAsync(galleryApiUrl);
                var users = await _userHttpClient.GetAsync("/api/Authentication/get-all-users");


                if (galleries.IsSuccessStatusCode)
                { 
                    var gallery_content = await galleries.Content.ReadAsStringAsync();

                    var user_content = await users.Content.ReadAsStringAsync();

                    Users = JsonSerializer.Deserialize<List<AuthenticationGetDto>>(user_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                       
                    if (Id.HasValue)
                    {

                        var singleGallery = JsonSerializer.Deserialize<GalleryGetDto>(gallery_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        Galleries = new List<GalleryGetDto> { singleGallery };

                    }
                    else
                    {
                        Galleries = JsonSerializer.Deserialize<List<GalleryGetDto>>(gallery_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
                            Galleries = Galleries.Where(g => g.CreatedBy == selectedUser.Code).ToList();
                        }
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
