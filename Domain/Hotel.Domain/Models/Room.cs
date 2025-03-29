using Infrastructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Models
{
    public class Room : BasicEntityWithAuditInfo
    {
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public string Category { get; set; }
        public string RoomTypeName { get; set; }
        public string? Description { get; set; }
        public int NumberOfAdults { get; set; }
        public int? Price { get; set; }
        public int NumberOfChildren { get; set; }
    }
}
