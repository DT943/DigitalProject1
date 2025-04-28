using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class MemberSecurityQuestions : BasicEntity
    {
        public string Question {  get; set; }

        public string Answer { get; set; }
    }
}
