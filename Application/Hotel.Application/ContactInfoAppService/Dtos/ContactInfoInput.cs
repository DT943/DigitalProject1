using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Hotel.Application.ContactInfoAppService.Dtos
{
    public class CotactInfoCreateDto : IValidatableDto
    {
        public int HotelId { get; set; }
        public string Category { get; set; }
        public string ContactType { get; set; }
        public bool IsPrimary { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Url { get; set; }
        public string ResponsiblePerson { get; set; }

    }
    public class CotactInfoUpdateDto : IEntityUpdateDto
    {
        public int HotelId { get; set; }
        public string Category { get; set; }
        public string ContactType { get; set; }
        public bool IsPrimary { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Url { get; set; }
        public string ResponsiblePerson { get; set; }

    }




}
