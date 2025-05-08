using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace CMS.Application.StaticComponentAppService.Dto
{ 
    public class StaticComponentCreateDto : IValidatableDto
    {
         public string Type { get; set; }
        public string Content { get; set; }
        public int Position { get; set; }

    }

    public class StaticComponentUpdateDto : IEntityUpdateDto
    {
         public string Type { get; set; }
        public string Content { get; set; }
        public int Position { get; set; }

    }
}
