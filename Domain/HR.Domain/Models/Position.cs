using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace HR.Domain.Models
{
    public class Position : BasicEntityWithAuditAndFakeDelete
    {
        public string Name { get; set; }
    }
}
