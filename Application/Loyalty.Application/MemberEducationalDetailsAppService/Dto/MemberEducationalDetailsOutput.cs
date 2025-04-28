using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.MemberEducationalDetailsAppService.Dto
{
    public class MemberEducationalDetailsGetDto
    {
        public int Id { get; set; }

        public string EducationType { get; set; }

        public string Education { get; set; }
    }

    public class MemberEducationalDetailsGetAllDto
    {
        public int Id  { get; set; }
        public string EducationType { get; set; }

        public string Education { get; set; }
    }
}
