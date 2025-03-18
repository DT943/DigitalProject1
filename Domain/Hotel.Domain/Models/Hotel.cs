using Infrastructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Models
{
    public class Hotel : BasicEntityWithAuditInfo
    {
        public string Name { get; set; }

        public string POS { get; set; }
        public string Governate { get; set; }
        public string StreetAddress { get; set; }

        public int Rank { get; set; } // 1-5 stars

        public List<Room> Rooms { get; set; } = new List<Room>();
        public IEnumerable<HotelGallery> HotelGallery { get; set; }
        // validation 10 
        public IEnumerable<ContactInfo> ContactInfo { get; set; }

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
