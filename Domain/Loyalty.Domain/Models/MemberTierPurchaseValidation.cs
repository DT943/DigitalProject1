using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class MemberTierPurchaseValidation : BasicEntity
    {
        public int MemberTierDetails { get; set; }

        public string CIS {  get; set; }

        public int AmountInUsd { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime ExtendedValidationDate { get; set; }


    }
}
