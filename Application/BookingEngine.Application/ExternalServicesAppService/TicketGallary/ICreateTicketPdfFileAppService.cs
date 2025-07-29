using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.ExternalServicesAppService.TicketGallary
{
    public interface ICreateTicketPdfFileAppService
    {
        Task<string> UploadFileToGalleryAsync(
              byte[] fileBytes,
              string title,
              string fileName,
              string caption,
              string description,
              string altText,
              int galleryId = 3);
    }
}
