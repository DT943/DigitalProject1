using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PDFTicketAppService.Dtos;

namespace BookingEngine.Application.PDFTicketAppService
{
    public interface IPDFTicketAppService
    {
        Task<byte[]> GenerateFromTemplate(PDFTicketCreateDto dto, string stripeAmount, string currency);
        Task<string> DownloadPdfAsync(string sessionId, string pnr);
    }
}
