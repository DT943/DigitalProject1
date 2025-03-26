using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hotel.Application.HotelGalleryAppService.Dtos
{
    public class HotelGalleryOutputDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string? GalleryName { get; set; }
        public string? GalleryCode { get; set; }
        public string? GalleryType { get; set; }

    }
    public class HotelGalleryDetailsOutputDto
    {
            public int Id { get; set; }
            public int HotelId { get; set; }

            public string GalleryName { get; set; }
            public string GalleryType { get; set; }
            public IEnumerable<FileGetModel> Files { get; set; }
    }
    public class FileGetModel
    {
        public PhysicalFileResult FilePhysicalPath { get; set; }

        public string FileUrlPath { get; set; }

    }


}