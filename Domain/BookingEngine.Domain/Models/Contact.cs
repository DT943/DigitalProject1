using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class Contact: BasicEntity
    {
        [MaxLength(10)]
        public string? Title { get; set; }

        [MaxLength(100)]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(15)] // adjust based on your expected phone number length
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(10)] // country codes are usually short (e.g. "US", "DE", etc.)
        public string CountryCode { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(100)]
        public string? CountryName { get; set; }

        [MaxLength(100)]
        public string? CityName { get; set; }

        // Navigation property
        public ICollection<PassengerInfo> Passengers { get; set; } = new List<PassengerInfo>();

    }
}
