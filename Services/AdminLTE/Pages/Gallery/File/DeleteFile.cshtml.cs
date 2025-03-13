using AdminLTE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace AdminLTE.Pages.Gallery.File
{
    public class DeleteFileModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteFileModel(HttpClientService httpClientService)
        {
            _httpClient = httpClientService.GetHttpClient("7181");
        }

        [BindProperty(Name = "selectedFileIds")]
        public string FileIds { get; set; } // Keeping as string, parsing as long[]
        [BindProperty(SupportsGet = true)]
        public int GalleryId { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(FileIds))
            {
                return BadRequest("No file IDs provided.");
            }

            var fileIdList = FileIds.Split(',').Select(long.Parse).ToList(); // Use long instead of int

            foreach (var id in fileIdList)
            {
                var response = await _httpClient.DeleteAsync($"/File/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return RedirectToPage("/Error", new { message = $"API Error: {response.StatusCode} - {errorMessage}" });
                }
            }

            return RedirectToPage("/Gallery/Index");
        }

        public async Task<IActionResult> OnGetAsync()
        {

            if (TempData.TryGetValue("GalleryId", out var galleryIdObj) && galleryIdObj is int galleryId)
            {
                if (TempData["FileId"] is string stringValue && long.TryParse(stringValue, out long fileId))
                {
                    var response = await _httpClient.DeleteAsync($"/File/{fileId}");

                    if (response.IsSuccessStatusCode)
                    {
                        // Store the galleryId in TempData again for the redirect
                        TempData["GalleryId"] = galleryId;
                        TempData.Keep("GalleryId");
                        return RedirectToPage("/Gallery/File/Index");
                    }
                    else
                    {
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        return RedirectToPage("/Error", new { message = $"API Error: {response.StatusCode} - {errorMessage}" });
                    }
                }
            }

            return RedirectToPage("/Error", new { message = "GalleryId or FileId not found." });
        }
    }
}
