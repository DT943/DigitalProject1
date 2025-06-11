using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.TravelUpdatesAppService.Dto
{
    public class TravelUpdatesGetDto
    {
        public int Id { get; set; }
        public string? Header { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? CreatedDate { get; set; } 
    }
}
