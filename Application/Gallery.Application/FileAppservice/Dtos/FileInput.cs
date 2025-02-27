using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Gallery.Application.FileAppservice.Dtos
{
    public class FileCreateDto : IValidatableDto
    {
        public string Name { get; set; }
        public string FileType { get; set; }
        public long Size { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Metadata { get; set; }
        public int GalleryId { get; set; }
    }

    public class FileUpdateDto : IEntityUpdateDto
    {
        public string Name { get; set; }
        public string FileType { get; set; }
        public long Size { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Metadata { get; set; }
        public int GalleryId { get; set; }
    }
}
