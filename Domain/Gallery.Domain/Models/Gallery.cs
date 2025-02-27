using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Gallery.Domain.Models
{
    public class Gallery : BasicEntityWithAuditInfo
    {
        public string Name { get; set; }

        // Navigation property to represent multiple files in a gallery
        public ICollection<File> Files { get; set; } // Collection of files belonging to the gallery
    }
}
