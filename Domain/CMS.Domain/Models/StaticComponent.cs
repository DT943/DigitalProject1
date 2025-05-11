using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace CMS.Domain.Models
{
    public class StaticComponent : BasicEntityWithAuditInfo
    {
        public string Type { get; set; }  // Example: "Text", "Image", "Video"

        public string Content { get; set; }  // Stores text or JSON config

        public int Position { get; set; }

        public string Language { get; set; }
    }
}
