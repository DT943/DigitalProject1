using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.MailModoAppService.Dtos
{
    public class MailModoCreateDto : IValidatableDto
    {
        public string PNR { get; set; }
        public string Email { get; set; }

        public string URL { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

    }
    public class MailModoUpdateDto : IEntityUpdateDto
    {
    }

    }


