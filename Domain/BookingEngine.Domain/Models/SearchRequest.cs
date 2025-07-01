using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class SearchRequest : BasicEntity
    {
        [Required]
        public int OriginId { get; set; }

        [Required]
        public int DestinationId { get; set; }


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
        [Required]

        public DateTime CreatedAt { get; set; }
        [Required]

        public float ExecutionTime { get; set; }
        [Required]

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }

    }

}
