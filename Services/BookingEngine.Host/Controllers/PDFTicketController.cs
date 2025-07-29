using System.Threading.Tasks;
using BookingEngine.Application.PDFTicketAppService;
using BookingEngine.Application.PDFTicketAppService.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace BookingEngine.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PDFTicketController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IPDFTicketAppService _PDFTicketAppService;

        public PDFTicketController(IWebHostEnvironment env, IPDFTicketAppService pDFTicketAppService)
        {
            _env = env;
            _PDFTicketAppService = pDFTicketAppService;
        }
        


        

        [AllowAnonymous]
        [HttpGet("DownloadTicketPDF")]
        public async Task<IActionResult> DownloadTicketPDF([FromHeader] string SessionId, [FromHeader] string PNR)
        {
            try
            {
                var fileUrl = await _PDFTicketAppService.DownloadPdfAsync(SessionId, PNR);

                if (fileUrl == null)
                {
                    return NotFound("PDF file not found or is empty.");
                }

                return Ok(new { fileUrl = fileUrl });
            }
            catch (HttpRequestException httpEx)
            {
                return NotFound($"Error fetching the PDF: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Unexpected error occurred: {ex.Message}");
            }
        }

    }
}
