using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.MemberTelephoneDetailsAppService.Dto
{
    public class MemberTelephoneDetailsCreateDto : IValidatableDto
    {
        [MaxLength(100)]
        public string TelephoneType { get; set; }

        [MaxLength(100)]
        public string CountryCode { get; set; }

        [MaxLength(20)]
        public string RegionalCode { get; set; }

        [MaxLength(20)]
        public string Number { get; set; }

        public bool Contactable { get; set; }
    }
    public class MemberTelephoneDetailsUpdateDto : IEntityUpdateDto
    {
        [MaxLength(100)]
        public string TelephoneType { get; set; }

        [MaxLength(100)]
        public string CountryCode { get; set; }

        [MaxLength(20)]
        public string RegionalCode { get; set; }

        [MaxLength(20)]
        public string Number { get; set; }

        public bool Contactable { get; set; }
    }

}
