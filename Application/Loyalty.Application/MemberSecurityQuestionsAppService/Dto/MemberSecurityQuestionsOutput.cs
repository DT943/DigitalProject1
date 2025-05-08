using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.MemberSecurityQuestionsAppService.Dto
{
    public class MemberSecurityQuestionsGetDto
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }
    }


    public class MemberSecurityQuestionsGetAllDto
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
