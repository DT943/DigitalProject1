using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Gallery.Application.GalleryAppService.Dtos
{
    public class GalleryCreateDto : IValidatableDto
    {
        //Test 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

    }

    public class GalleryUpdateDto : IEntityUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }


    }
}

