using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Hotel.Application.HotelGalleryAppService.Dtos
{
    public class HotelGalleryCreateDto: IValidatableDto
    {
   
        public int HotelId { get; set; }
        public string GalleryName { get; set; }
        public string? GalleryCode { get; set; }
        public string GalleryType { get; set; }

    }
    public class HotelGalleryUpdateDto : IEntityUpdateDto
    {
           
        public string GalleryName { get; set; }
        public string? GalleryCode { get; set; }
        public string GalleryType { get; set; }

    }

}