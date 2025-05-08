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
    public class Component : BasicEntityWithAuditInfo
    {

        [Required]
        public int SegmentID { get; set; }

        [Required, MaxLength(100)]
        public string Type { get; set; }  // Example: "Text", "Image", "Video"

        public string Content { get; set; }  // Stores text or JSON config

        public int Position { get; set; }

        // Navigation Property
        [ForeignKey("SegmentID")]
        public Segment Segment { get; set; }
    }
}
