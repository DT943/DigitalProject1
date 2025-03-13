using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Drawing;

namespace AdminLTE.Pages.Page
{
    public class PagesModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Language { get; set; }

        [BindProperty(SupportsGet = true)]
        public string POS { get; set; }

        public IActionResult OnGetPartialView()
        {
            // Create a model for the partial view
            var model = new PartialIndexModel
            {
                Language = Language,
                POS = POS
            };

            // Return the partial view
            return Partial("_PartialView", model);
        }
    }


}
