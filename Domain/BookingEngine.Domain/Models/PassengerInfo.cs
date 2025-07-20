using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class PassengerInfo 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(3)]
        public string PassengerTypeCode { get; set; }

        [Required]
        [StringLength(100)]
        public string GivenName { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }


        public string? CountryCode { get; set; }
        public List<string>? FileUrlPath { get; set; }


        [Required]
        [StringLength(10)]
        public string NameTitle { get; set; }


        public int? TelephoneId { get; set; }
        [ForeignKey("TelephoneId")]
        public Telephone? Telephone { get; set; }

        public int? PassportId { get; set; }
        [ForeignKey("PassportId")]

        public Passport? Passport { get; set; }

        public int ContactId { get; set; }
        [ForeignKey("ContactId")]

        public Contact Contact { get; set; }


    }

    public class Telephone
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string? AreaCityCode { get; set; }

        [StringLength(5)]
        public string? CountryAccessCode { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; }

    }

    public class Passport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string? DocID { get; set; }

        [Required]
        public DateOnly? ExpireDate { get; set; }

    }


}


