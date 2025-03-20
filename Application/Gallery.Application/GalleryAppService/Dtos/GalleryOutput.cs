using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Application.FileAppservice.Dtos;

namespace Gallery.Application.GalleryAppService.Dtos
{

    public class GalleryGetDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
         public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string Type { get; set; }
        public IEnumerable<string> FileTypes { get; set; }
    }
}
