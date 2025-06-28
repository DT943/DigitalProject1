using System.ComponentModel.DataAnnotations;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class SearchRequest : BasicEntity
    {
        [Required]
        public string Origin { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public DateTime? Date_Return { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }

        public int Infants { get; set; }

        [Required]
        public string FlightClass { get; set; }

        [Required]
        public string FlightType { get; set; }

        [Required]
        public string Pos { get; set; }
    }

}
