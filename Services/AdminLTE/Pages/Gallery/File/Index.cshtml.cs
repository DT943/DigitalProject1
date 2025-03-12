using AdminLTE.Services;
using Authentication.Application.Dtos;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.GalleryAppService.Dtos;
using Gallery.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace AdminLTE.Pages.Gallery.File
{
    public class FileModel : PageModel
    {
        private readonly HttpClient _httpClient;

        private readonly HttpClient _userHttpClient;

        public FileModel(HttpClientService httpClientService)
        {
            // Retrieve the configured HttpClient from the HttpClientService
            _httpClient = httpClientService.GetHttpClient("7181");
            _userHttpClient = httpClientService.GetHttpClient("7182");


        }
        [BindProperty(SupportsGet = true)]
        public string SelectedUser { get; set; }

        [BindProperty]
        public FileUpdateDto FileUpdate { get; set; } = new FileUpdateDto();

        [BindProperty]
        public List<AuthenticationGetDto> Users { get; set; } = new List<AuthenticationGetDto>();

        [BindProperty(SupportsGet = true)]
        public int GalleryId { get; set; }

        [BindProperty]
        public List<FileGetDto> Files { get; set; } = new List<FileGetDto>();

        public async Task<IActionResult> OnGetAsync(int? Id, int galleryId)
        {
            try
            {
                //GalleryId = galleryId;
                /*
                // Retrieve the galleryId from TempData
                if (TempData.TryGetValue("GalleryId", out var galleryId))
                {
                    GalleryId = (int)galleryId;
                }
                else
                {
                    // Handle the case where galleryId is not found in TempData
                    return RedirectToPage("/Error", new { message = "GalleryId not found." });
                }
                */


                string fileApiUrl = $"/File/getby-galleryid/{galleryId}";

                if (Id.HasValue)
                {
                    fileApiUrl += $"/{Id.Value}";

                }

                var files = await _httpClient.GetAsync(fileApiUrl);
                var users = await _userHttpClient.GetAsync("/api/Authentication/get-all-users");


                if (files.IsSuccessStatusCode)
                {

                    var file_content = await files.Content.ReadAsStringAsync();

                    if (users.IsSuccessStatusCode)
                    {

                        var user_content = await users.Content.ReadAsStringAsync();

                        Users = JsonSerializer.Deserialize<List<AuthenticationGetDto>>(user_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        if (Id.HasValue)
                        {

                            var singleFile = JsonSerializer.Deserialize<FileGetDto>(file_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                            Files = new List<FileGetDto> { singleFile };

                        }
                        else
                        {

                            Files = JsonSerializer.Deserialize<List<FileGetDto>>(file_content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                        }
                        foreach (var user in Users)
                        {
                            StringUtility.ConvertStringsToTitleCase(user);
                        }
                        foreach (var File in Files)
                        {
                            StringUtility.ConvertStringsToTitleCase(File);
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
                                Files = Files.Where(g => g.CreatedBy == selectedUser.Code).ToList();
                            }
                        }

                    }
                    else
                    {
                        // Log the error (optional)
                        var errorMessage = await users.Content.ReadAsStringAsync();
                        // Redirect to the error page with a custom message
                        return RedirectToPage("/Error", new { message = $"API Error: {users.StatusCode} - {errorMessage}" });
                    }
                }
                else
                {
                    // Log the error (optional)
                    var errorMessage = await users.Content.ReadAsStringAsync();
                    // Redirect to the error page with a custom message
                    return RedirectToPage("/Error", new { message = $"API Error: {files.StatusCode} - {errorMessage}" });
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

