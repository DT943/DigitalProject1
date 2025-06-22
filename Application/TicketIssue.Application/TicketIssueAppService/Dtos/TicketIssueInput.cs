using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace TicketIssue.Application.TicketIssueAppService.Dtos
{
    public class TicketIssueCreateDto   : IValidatableDto
    {
        public string HtmlContext { get; set; }

    }

    public class TicketIssueUpdateDto : IEntityUpdateDto
    {
        public string HtmlContext { get; set; }

    }
}
