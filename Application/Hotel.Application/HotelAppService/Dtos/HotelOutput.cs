using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWCore.Application.POSAppService.Dtos;
using CWCore.Domain.Models;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Hotel.Application.RoomAppService.Dtos;
using Hotel.Domain.Models;
using Infrastructure.Application.BasicDto;

namespace Hotel.Application.HotelAppService.Dtos
{
    public class HotelGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string POS { get; set; }
        public string Governate { get; set; }
        public string StreetAddress { get; set; }
        public int Rank { get; set; }
        public IEnumerable<ContactInfoGetDto> ContactInfo { get; set; } = Enumerable.Empty<ContactInfoGetDto>();
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
    public class HotelGetDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public POSGetDto POS { get; set; }
        public string Governate { get; set; }
        public string StreetAddress { get; set; }

        public int Rank { get; set; }
        public IEnumerable<RoomOutputDto> Rooms { get; set; } = Enumerable.Empty<RoomOutputDto>();
        public IEnumerable<HotelGalleryOutputDto> HotelGallery { get; set; } = Enumerable.Empty<HotelGalleryOutputDto>();
        public IEnumerable<ContactInfoGetDto> ContactInfo { get; set; } = Enumerable.Empty<ContactInfoGetDto>();
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
    public class ContactInfoGetDto 
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ResponsiblePerson { get; set; }

    }


}
