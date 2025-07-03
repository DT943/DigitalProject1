using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.PassengerInfo.Dtos
{
    public class PassengerInfoGetDto
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string GivenName { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public string NameTitle { get; set; }

        public TelephoneGetDto Telephone { get; set; }

        public PassportGetDto Passport { get; set; }
    }

    public class TelephoneGetDto
    {
        public int Id { get; set; }

        public string AreaCityCode { get; set; }

        public string CountryAccessCode { get; set; }

        public string PhoneNumber { get; set; }

    }

    public class PassportGetDto
    {
        public int Id { get; set; }
        public string DocID { get; set; }
        public DateTime ExpireDate { get; set; }
    }

}
