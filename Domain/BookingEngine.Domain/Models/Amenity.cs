using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class Amenity : BasicEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string Description { get; set; }
    }
}
