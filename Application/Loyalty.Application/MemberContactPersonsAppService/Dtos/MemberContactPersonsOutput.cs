using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.MemberContactPersonsAppService.Dtos
{
    public class MemberContactPersonsGetDto
    {
        public int Id { get; set; }
        public string ContactType { get; set; }
        public string Status { get; set; }
    }

    public class MemberContactPersonsGetAllDto
    {
        public int Id { get; set; }
        public string ContactType { get; set; }
        public string Status { get; set; }
    }
}
