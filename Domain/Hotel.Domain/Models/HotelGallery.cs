using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Infrastructure.Domain.Models;

namespace Hotel.Domain.Models
{
    public class HotelGallery : BasicEntityWithAuditInfo
    {
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public string GalleryName { get; set; }
        public string GalleryCode { get; set; }
        public string GalleryType { get; set; }

    }
}