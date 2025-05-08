using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace CMS.Domain.Models
{
    public class ComponentMetadata : BasicEntityWithAuditInfo
    {
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
