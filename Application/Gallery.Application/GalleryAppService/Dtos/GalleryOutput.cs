using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Application.FileAppservice.Dtos;

namespace Gallery.Application.GalleryAppService.Dtos
{

    public class GalleryGetDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

    }
}
