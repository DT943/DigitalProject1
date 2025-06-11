using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace CMS.Application.TravelUpdatesAppService.Dto
{
    public class TravelUpdatesCreateDto : IValidatableDto
    {
        public string? Header { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? CreatedDate { get; set; }
    }

    public class TravelUpdatesUpdateDto : IEntityUpdateDto
    {
        public string? Header { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime? CreatedDate { get; set; }

    }
}
