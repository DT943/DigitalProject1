using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class Location : BasicEntity
    {
        [Required]
        public string CountryCode { get; set; }

        [Required]
        public string LocationCode { get; set; }

        [Required]
        public string CountryName { get; set; }



    }
}
