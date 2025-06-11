using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace CMS.Domain.Models
{
    public class TravelUpdates : BasicEntity
    {
        public string? Header { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}
