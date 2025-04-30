using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class MemberEducationalDetails : BasicEntity
    {
        [MaxLength(500)]
        public string EducationType { get; set; }

        [MaxLength(500)]
        public string Education { get; set; }
    }
}
