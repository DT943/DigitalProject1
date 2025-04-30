using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class MemberContactPersons : BasicEntity
    {
        [MaxLength(500)]
        public string ContactType {  get; set; }

        [MaxLength(100)]
        public string Status { get; set; }
    }
}
