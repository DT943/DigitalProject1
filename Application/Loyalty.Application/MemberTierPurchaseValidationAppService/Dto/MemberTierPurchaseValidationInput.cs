using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.MemberTierPurchaseValidationAppService.Dto
{
    public class MemberTierPurchaseValidationCreateDto : IValidatableDto
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int? MemberTierDetails { get; set; }

        public string CIS { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        public int? AmountInUsd { get; set; }

        public int NumberOfDays {  get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime? ExtendedValidationDate { get; set; }
    }

    public class MemberTierPurchaseValidationUpdateDto : IEntityUpdateDto
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int? MemberTierDetails { get; set; }

        public string CIS { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]

        public int? AmountInUsd { get; set; }
        public int NumberOfDays { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime? ExtendedValidationDate { get; set; }
    }
}
