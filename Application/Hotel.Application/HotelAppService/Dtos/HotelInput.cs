using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Application.FileAppservice.Dtos;
using Hotel.Application.ContactInfoAppService.Dtos;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Hotel.Domain.Models;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Hotel.Application.HotelAppService.Dtos
{
    public class HotelCreateDetailsDto : IValidatableDto
    {
        public string Name { get; set; }
        public string POS { get; set; }
        public string Country { get; set; }
        public string Governate { get; set; }
        public string StreetAddress { get; set; }
        public string Url { get; set; }

        public int Rank { get; set; }
        public IEnumerable<RoomCreateDto> Rooms { get; set; } = Enumerable.Empty<RoomCreateDto>();

        // public FileCreateDto? CommercialDealsFile { get; set;}
        // public string? CommercialDealsFileUrlPath { get; set; }
        // public string? CommercialDealsFileCode { get; set; }

        public IEnumerable<HotelGalleryCreateDto> HotelGallery { get; set; } = Enumerable.Empty<HotelGalleryCreateDto>();
        public IEnumerable<CotactInfoCreateDto> ContactInfo { get; set; } = Enumerable.Empty<CotactInfoCreateDto>();
        public bool HasAirConditioning { get; set; }
        public bool HasBar { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasPool { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasWifi { get; set; }
        public bool HasSPA { get; set; }
        public bool ArePetsAllowed { get; set; }

    }

    public class HotelCreateDto : IValidatableDto
    {
        public string Name { get; set; }
        public string POS { get; set; }
        public string Governate { get; set; }
        public string StreetAddress { get; set; }
        public string Url { get; set; }

        public int Rank { get; set; }
        public IEnumerable<HotelGalleryCreateDto> HotelGallery { get; set; } = Enumerable.Empty<HotelGalleryCreateDto>();

        public IEnumerable<CotactInfoCreateDto> ContactInfo { get; set; } = Enumerable.Empty<CotactInfoCreateDto>();
        public bool HasAirConditioning { get; set; }
        public bool HasBar { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasPool { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasWifi { get; set; }
        public bool HasSPA { get; set; }
        public bool ArePetsAllowed { get; set; }

    }

    public class HotelUpdateDto : IEntityUpdateDto
    {

        public string Name { get; set; }
        public string POS { get; set; }
        public string Country { get; set; }
        public string Governate { get; set; }
        public string StreetAddress { get; set; }
        public string Url { get; set; }
        public int Rank { get; set; }
        public IEnumerable<CotactInfoUpdateDto> ContactInfo { get; set; } = Enumerable.Empty<CotactInfoUpdateDto>();
        public bool HasAirConditioning { get; set; }
        public bool HasBar { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasPool { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasWifi { get; set; }
        public bool HasSPA { get; set; }
        public bool ArePetsAllowed { get; set; }
    }

}