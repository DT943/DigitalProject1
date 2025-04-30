using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.MemberHobbiesDetailsAppService.Dto
{
    public class MemberHobbiesDetailsGetDto
    {
        public int Id { get; set; }
        public string HobbyName { get; set; }
    }


    public class MemberHobbiesDetailsGetAllDto
    {
        public int Id { get; set; }
        public string HobbyName { get; set; }
    }
}
