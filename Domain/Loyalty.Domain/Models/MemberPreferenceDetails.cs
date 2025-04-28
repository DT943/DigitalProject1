using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class MemberPreferenceDetails : BasicEntity
    {
        [MaxLength(200)]
        public string Level { get; set; }
    }
}
