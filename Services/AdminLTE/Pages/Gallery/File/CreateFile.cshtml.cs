using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Offer.Application.FlightOfferAppService.Dtos;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Net.Http;
using System.IO;
using Gallery.Domain.Models;
using Offer.Domain.Models;
using System.Reflection;

namespace AdminLTE.Pages.Gallery.File
{
    public class CreateFileModel : PageModel
    {
            private readonly HttpClient _httpClient;

        public CreateFileModel(HttpClientService httpClientService)
        {
            _httpClient = httpClientService.GetHttpClient("7181");
        }
        [BindProperty]
        public FileCreateDto File { get; set; } 
        
        [BindProperty(SupportsGet = true)]
        public int GalleryId { get; set; }

        public async Task<IActionResult> OnGetAsync(int galleryId)
        {
            GalleryId = galleryId;
            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                // Return to the form with errors
                return Page();
            }
            StringUtility.ConvertStringsToLowercase(File);

            var formData = new MultipartFormDataContent();
            if (File.File != null)
            {
                var fileContent = new StreamContent(File.File.OpenReadStream());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(File.File.ContentType);
                formData.Add(fileContent, "File", File.File.FileName);
            }

            formData.Add(new StringContent(File.Title), "Title");
            formData.Add(new StringContent(File.Caption ?? string.Empty), "Caption");
            formData.Add(new StringContent(File.Description ?? string.Empty), "Description");
            formData.Add(new StringContent(File.AlternativeText ?? string.Empty), "AlternativeText");
            formData.Add(new StringContent(File.GalleryId.ToString()), "GalleryId");


            var response = await _httpClient.PostAsync("/File", formData);


            if (response.IsSuccessStatusCode)
            {
                //TempData["GalleryId"] = File.GalleryId;
                //return RedirectToPage("/Gallery/File/Index");

                // Redirect to a success page or another action
                return RedirectToPage("/Gallery/File/Index", new { galleryId = File.GalleryId });
            }
            else
            {
                // Log the error (optional)
                var errorMessage = await response.Content.ReadAsStringAsync();
                // Redirect to the error page with a custom message
                return RedirectToPage("/Error", new { message = $"API Error: {response.StatusCode} - {errorMessage}" });

            }
        }

    }
}
