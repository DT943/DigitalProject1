using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.PassengerInfo.Dtos
{
    public class PassengerInfoCreateDto : IValidatableDto
    {

        public string PassengerTypeCode { get; set; }

        public string GivenName { get; set; }

        public string Surname { get; set; }

        public DateOnly BirthDate { get; set; }

        public string CountryCode { get; set; }

        public string NameTitle { get; set; }

        public TelephoneCreateDto Telephone { get; set; }

        public PassportCreateDto Passport { get; set; }
       // public List<string> FileUrlPath { get; set; }

        //public ContactInfoCreateDto ContactInfo { get; set; }

    }

    public class TelephoneCreateDto : IValidatableDto
    {
        public string AreaCityCode { get; set; }

        public string CountryAccessCode { get; set; }

        public string PhoneNumber { get; set; }

    }

    public class PassportCreateDto : IValidatableDto
    {
        public string DocID { get; set; }
        public DateOnly ExpireDate { get; set; }
    }


    public class PassengerInfoUpdateDto : IEntityUpdateDto
    {

        public string PassengerTypeCode { get; set; }

        public string GivenName { get; set; }

        public string Surname { get; set; }
        public string CountryCode { get; set; }


        public DateOnly BirthDate { get; set; }

        public string NameTitle { get; set; }

        public TelephoneCreateDto Telephone { get; set; }

        public PassportCreateDto Passport { get; set; }

    }

    public class TelephoneUpdateDto : IEntityUpdateDto
    {

        public string AreaCityCode { get; set; }

        public string CountryAccessCode { get; set; }

        public string PhoneNumber { get; set; }

    }

    public class PassportUpdateDto : IEntityUpdateDto
    {
        public string DocID { get; set; }
        public DateOnly ExpireDate { get; set; }
    }

}