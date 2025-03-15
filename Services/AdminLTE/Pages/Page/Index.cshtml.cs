using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Drawing;
using AdminLTE.Services;
using System.Net.Http;
using Gallery.Domain.Models;

namespace AdminLTE.Pages.Page
{
    public class PagesModel : PageModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty(SupportsGet = true)]
        public string Language { get; set; }

        [BindProperty(SupportsGet = true)]
        public string POS { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Child { get; set; }

        public string Domain { get; set; }

        public PagesModel(HttpClientService httpClientService)
        {

            _httpClient = httpClientService.GetHttpClient("7036");
        }
        public async Task<ActionResult> OnGetPartialView()
        {
            return Page();
        }
    }
}
