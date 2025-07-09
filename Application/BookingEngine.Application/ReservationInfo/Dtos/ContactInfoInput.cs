using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PassengerInfo.Dtos;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.ReservationInfo.Dtos
{
    public class ContactInfoCreateDto : IValidatableDto
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public ICollection<PassengerInfoCreateDto> Passengers { get; set; }

    }
    public class ContactInfoUpdateDto : IEntityUpdateDto
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public ICollection<PassengerInfoUpdateDto> Passengers { get; set; }

    }


}
