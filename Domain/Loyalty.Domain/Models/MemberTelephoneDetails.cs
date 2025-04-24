using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace MemberDemographicsAndProfile.Models
{
    public class MemberTelephoneDetails : BasicEntity
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
