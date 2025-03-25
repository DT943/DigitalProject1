using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.ContactInfoAppService.Dtos
{
    public class ContactInfoGetDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string ContactType { get; set; }
        public bool IsPrimary { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Url { get; set; }
        public string? ResponsiblePerson { get; set; }
        public string? ResponsiblePersonRole { get; set; }
        public string? DisplayLabel { get; set; }

    }
}
