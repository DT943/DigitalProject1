using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace CMS.Domain.Models
{
    public class Page : BasicEntityWithAuditAndFakeDelete
    {

        public string PageUrlName { get; set; }
        public string Language { get; set; }
        public string POS { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public ICollection<Segment> Segments { get; set; } = new List<Segment>();

    }
}
