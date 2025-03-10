using AdminLTE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminLTE.Pages.Gallery.File
{
    public class DeleteFileModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public DeleteFileModel(HttpClientService httpClientService)
        {
            _httpClient = httpClientService.GetHttpClient("7181");
        }
        [BindProperty]
        public string FileIds { get; set; } // Using long since you prefer long IDs


        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(FileIds))
            {
                return BadRequest("No file IDs provided.");
            }
            var fileIdList = FileIds.Split(',').Select(int.Parse).ToList();

            foreach (var id in fileIdList)
            {
                var response = await _httpClient.DeleteAsync($"/File/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    return BadRequest($"Failed to delete file with ID: {id}");
                }
            }

            return RedirectToPage("/Gallery/Index");
        }

    }
}
