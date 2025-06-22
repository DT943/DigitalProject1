using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace TicketIssue.Domain.Models
{
    public class TicketIssue  : BasicEntity
    {
        public string HtmlContext { get; set; }
    }
}
