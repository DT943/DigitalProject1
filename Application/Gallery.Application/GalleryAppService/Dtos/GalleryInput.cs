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
        public string Name { get; set; }

    }

    public class GalleryUpdateDto : IEntityUpdateDto
    {
        public string Name { get; set; }
    }
}

