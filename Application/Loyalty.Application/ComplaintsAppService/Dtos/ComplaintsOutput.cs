using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.ComplaintsAppService.Dtos
{
    public class ComplaintsGetDto
    {
        public int Id { get; set; }

        public string CIS { get; set; }

        public string Description { get; set; }
    }
}
