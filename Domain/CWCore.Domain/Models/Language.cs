using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace CWCore.Domain.Models
{
    public class Language: BasicEntityWithAuditInfo
    {
        public string Name { get; set; }

        public string Code { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
