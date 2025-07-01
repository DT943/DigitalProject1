using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.AuditAppService.Dtos
{
    public class SearchRequestGetDto
    {
        public int OriginId { get; set; }

        public int DestinationId { get; set; }

        public DateTime Date { get; set; }

        public DateTime? Date_Return { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }

        public int Infants { get; set; }
        public string FlightClass { get; set; }

        public string FlightType { get; set; }

        public string Pos { get; set; }
        public DateTime CreatedAt { get; set; }

        public float ExecutionTime { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }




    }
}
