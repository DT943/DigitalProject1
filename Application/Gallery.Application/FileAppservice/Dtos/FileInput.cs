using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;
using Microsoft.AspNetCore.Http;

namespace Gallery.Application.FileAppservice.Dtos
{
    public class FileCreateDto : IValidatableDto
    {

        public string Title { get; set; }
        public string? GalleryCode { get; set; }
        
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public float? Size { get; set; }
        public string? Path { get; set; }
        public string? MimeType { get; set; }
        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }
        public string? FileUrlPath { get; set; }
        public TimeSpan? Duration { get; set; }
        public string? Caption { get; set; }
        public string? Description { get; set; }
        public string? AlternativeText { get; set; }
        public int GalleryId { get; set; }

        public string? GalleryCode { get; set; }

        public IFormFile File { get; set; }

    }

    public class FileUpdateDto : IEntityUpdateDto
    {
        public string Title { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public float? Size { get; set; }
        public string? Path { get; set; }
        public string? MimeType { get; set; }
        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }
        public TimeSpan? Duration { get; set; }
        public string? FileUrlPath { get; set; }
        public string? Caption { get; set; }
        public string? Description { get; set; }
        public string? AlternativeText { get; set; }
        public int GalleryId { get; set; }
    }

    public class FileUploadModel
    {
        public IFormFile File { get; set; }
    }

    public class FilePostModel
    {
        public string FilePath { get; set; }
    }

}
