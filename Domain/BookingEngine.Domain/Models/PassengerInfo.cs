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
    public class PassengerInfo: BasicEntityAndFakeDelete
    {
        [Required]
        [StringLength(10)]
        public string Type { get; set; }

        [Required]
        [StringLength(100)]
        public string GivenName { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]

        public string CountryCode { get; set; }


        [Required]
        [StringLength(10)]
        public string NameTitle { get; set; }

        public Telephone Telephone { get; set; }

        public Passport Passport { get; set; }
    }

    public class Telephone
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string AreaCityCode { get; set; }

        [StringLength(5)]
        public string CountryAccessCode { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public int PassengerInfoId { get; set; }
        [ForeignKey("PassengerInfoId")]
        public PassengerInfo Passenger { get; set; }
    }

    public class Passport
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string DocID { get; set; }

        [Required]
        public DateTime ExpireDate { get; set; }

        public int PassengerInfoId { get; set; }
        [ForeignKey("PassengerInfoId")]
        public PassengerInfo Passenger { get; set; }
    }

}
