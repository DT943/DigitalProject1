using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PassengerInfo.Dtos;

namespace BookingEngine.Application.ReservationInfo.Dtos
{
    public class ContactInfoGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }

        public ICollection<PassengerInfoGetDto> Passengers { get; set; }

    }




}
