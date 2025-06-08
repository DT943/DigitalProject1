using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.ComplaintsAppService.Dtos
{
    public class ComplaintsCreateDto : IValidatableDto
    {
        public string CIS { get; set; }

        public string Description { get; set; }
    }

    public class ComplaintsUpdateDto : IEntityUpdateDto
    {
        public string CIS { get; set; }

        public string Description { get; set; }
    }
}
