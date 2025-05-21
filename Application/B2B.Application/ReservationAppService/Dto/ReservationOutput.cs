using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.Validations;

namespace B2B.Application.ReservationAppService.Dto
{
    public class ReservationGetDto
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public string PNR { get; set; }
        public int? NumAdt { get; set; }

        public int? NumChd { get; set; }

        public int? NumInf { get; set; }
        [MaxLength(50)]
        public string? POS { get; set; }

        [MaxLength(50)]
        public string? FlightClass { get; set; }

        [MaxLength(50)]
        public string? OriginCode { get; set; }

        [MaxLength(100)]
        public string? OriginName { get; set; }

        [MaxLength(50)]
        public string? DestinationCode { get; set; }

        [MaxLength(100)]
        public string? DestinationName { get; set; }

        public DateOnly DepartureDate { get; set; }

        public TimeOnly DepartureTime { get; set; }

        public DateOnly ArrivalDate { get; set; }

        public TimeOnly ArrivalTime { get; set; }

        public decimal TotalFare { get; set; }

        public ICollection<SegmentsGetDto> Segments { get; set; }
        public ICollection<PassengersGetDto> Passengers { get; set; }
        public ICollection<ContactInfoGetDto> ContactInfo { get; set; }
        public ICollection<PNRDetailsGetDto> PNRDetails { get; set; }
    }
    public class SegmentsGetDto : IValidatableDto
    {
        public int Id { get; set; }

        [MaxLength(100)]

        public string OriginCode { get; set; }
        [MaxLength(100)]
        public string? OriginName { get; set; }
        public DateOnly DepartureDate { get; set; }

        public TimeOnly DepartureTime { get; set; }

        public DateOnly ArrivalDate { get; set; }

        public TimeOnly ArrivalTime { get; set; }
        [MaxLength(50)]

        public string FlightNumber { get; set; }

        public int ReservationiD { get; set; }
    }
    public class PassengersGetDto : IValidatableDto
    {
        public int Id { get; set; }

        public string type { get; set; }

        public string given_name { get; set; }

        public string surname { get; set; }

        public DateTime BirthDate { get; set; }

        public string telephone { get; set; }
    }
    public class ContactInfoGetDto : IValidatableDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? CountryCode { get; set; }

        public string Email { get; set; }

        public string? CountryName { get; set; }

        public string? CityName { get; set; }
    }
    public class PNRDetailsGetDto : IValidatableDto
    {
        public int Id { get; set; }
        public string PNR { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }

    }
}
