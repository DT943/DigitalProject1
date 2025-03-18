using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Domain.Models;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Hotel.Application.HotelAppService.Dtos
{
    public class HotelCreateDto : IValidatableDto
    {
        public string Name { get; set; }

        public string POS { get;set;}

        public string Governate { get; set; }
        public string StreetAddress { get; set; }
        public List<(string PhoneNumber, string Email, string ResponsiblePerson)> ContactInfo { get; set; }
            = new List<(string, string, string)>();
        public int Rank { get; set; } // 1-5 stars
        public List<Room> Rooms { get; set; } = new List<Room>();
        public int GalleryId { get; set; }
        public HotelGallery HotelGallery { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasBar { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasPool { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasWifi { get; set; }
        public bool HasSwimmingPool { get; set; }
        public bool ArePetsAllowed { get; set; }
    }

    public class HotelUpdateDto : IEntityUpdateDto
    {
        public string Name { get; set; }
        public string POS { get; set; }
        public string Governate { get; set; }
        public string StreetAddress { get; set; }
        public List<(string PhoneNumber, string Email, string ResponsiblePerson)> ContactInfo { get; set; }
            = new List<(string, string, string)>();
        public int Rank { get; set; } // 1-5 stars
        public List<Room> Rooms { get; set; } = new List<Room>();
        public int GalleryId { get; set; }
        public HotelGallery HotelGallery { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasBar { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasPool { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasWifi { get; set; }
        public bool HasSwimmingPool { get; set; }
        public bool ArePetsAllowed { get; set; }
    }
}

