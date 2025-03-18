using Infrastructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offer.Domain.Models
{
    public class Rule : BasicEntityWithAuditInfo
    {
        public string RuleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
