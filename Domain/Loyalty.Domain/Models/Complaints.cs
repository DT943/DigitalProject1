using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class Complaints : BasicEntity
    {
        public string CIS { get; set; }

        public string Description { get; set; }
    }
}
