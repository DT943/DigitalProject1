using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace CMS.Domain.Models
{
    public class Segment : BasicEntityWithAuditInfo
    {

        [Required]
        public int PageID { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Position { get; set; }

        // Navigation Properties
        [ForeignKey("PageID")]
        public Page Page { get; set; }

        public ICollection<Component> Components { get; set; } = new List<Component>();
    }
}
