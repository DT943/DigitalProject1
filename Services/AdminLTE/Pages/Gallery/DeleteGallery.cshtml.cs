using AdminLTE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminLTE.Pages.Gallery
{
    public class DeleteGalleryModel : PageModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty(Name = "selectedGalleryIds")]
        public string SelectedGalleryIds { get; set; }

        public DeleteGalleryModel(HttpClientService httpClientService)
        {
            _httpClient = httpClientService.GetHttpClient("7181");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(SelectedGalleryIds))
            {
                var galleryIds = SelectedGalleryIds.Split(',').Select(int.Parse).ToList();
                // Perform deletion logic for the selected IDs
                foreach (var id in galleryIds)
                {
                    var response = await _httpClient.DeleteAsync($"/Gallery/{id}");

                    if (!response.IsSuccessStatusCode)
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        return RedirectToPage("/Error", new { message = $"API Error: {response.StatusCode} - {errorMessage}" });
                    }
                }
            }

            return RedirectToPage("/Gallery/Index");
        }
    }
}
