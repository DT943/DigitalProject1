using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.AuditAppService.Dtos
{
    public class SearchRequestCreateDto : IValidatableDto
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime Date { get; set; }

        public DateTime? Date_Return { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }

        public int Infants { get; set; }
        public string FlightClass { get; set; }

        public string FlightType { get; set; }

        public string Pos { get; set; }

    }
    public class SearchRequestUpdateDto : IEntityUpdateDto
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public DateTime Date { get; set; }

        public DateTime? Date_Return { get; set; }

        public int Adults { get; set; }

        public int Children { get; set; }

        public int Infants { get; set; }
        public string FlightClass { get; set; }

        public string FlightType { get; set; }

        public string Pos { get; set; }



    }
}
