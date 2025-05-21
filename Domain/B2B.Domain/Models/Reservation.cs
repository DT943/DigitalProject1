using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace B2B.Domain.Models
{
    public class Reservation : BasicEntity
    {


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
        public ICollection<Segments> Segments { get; set; }
        public ICollection<Passengers> Passengers { get; set; }
        public ICollection<ContactInfo> ContactInfo { get; set; }
        public ICollection<PNRDetails> PNRDetails { get; set; }

    }


    public class Segments
    {
        [Key]
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

        public int ReservationiD {  get; set; }

        public Reservation Reservation { get; set; }
    }

    public class Passengers
    {
        [Key]
        public int Id { get; set; }
        public string type { get; set; }

        public string given_name { get; set; }

        public string surname {  get; set; }

        public DateTime BirthDate { get; set; }

        public string telephone { get; set; }
        public Reservation Reservation { get; set; }

    }

    public class ContactInfo
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? CountryCode { get; set; }

        public string Email { get; set; }

        public string? CountryName { get; set; }

        public string? CityName { get; set; }
        public Reservation Reservation { get; set; }

    }

    public class PNRDetails
    {
        [Key]
        public int Id { get; set; }
        public string PNR { get; set; }

        public string? Status {  get; set; }

        public string? Description { get; set; }
        public Reservation Reservation { get; set; }
    }


}
