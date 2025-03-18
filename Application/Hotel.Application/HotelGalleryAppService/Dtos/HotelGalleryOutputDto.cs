using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel.Application.HotelGalleryAppService.Dtos
{
    public class HotelGalleryOutputDto
    {
      
        public int HotelId { get; set; }
        public string GalleryName { get; set; }
        public string GalleryCode { get; set; }
        public string GalleryType { get; set; }

    }
}