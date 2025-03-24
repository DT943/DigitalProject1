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
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ResponsiblePerson { get; set; }

    }
}
