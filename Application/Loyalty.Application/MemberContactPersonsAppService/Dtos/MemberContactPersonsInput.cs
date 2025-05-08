using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.MemberContactPersonsAppService.Dtos
{
    public class MemberContactPersonsCreateDto : IValidatableDto
    {
        [MaxLength(500)]
        public string ContactType { get; set; }

        [MaxLength(100)]
        public string Status { get; set; }
    }

    public class MemberContactPersonsUpdateDto : IEntityUpdateDto
    {
        [MaxLength(500)]
        public string ContactType { get; set; }

        [MaxLength(100)]
        public string Status { get; set; }
    }
}
