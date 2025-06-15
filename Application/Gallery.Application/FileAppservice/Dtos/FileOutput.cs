using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gallery.Application.FileAppservice.Dtos
{
    public class FileGetDto
    {
        public string Code { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public float Size { get; set; }
        public string SizeUnit { get; set; } = "MB";
        [System.Text.Json.Serialization.JsonIgnore]
        public string Path { get; set; }
        public string MimeType { get; set; }
        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }
        public string? Caption { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? AlternativeText { get; set; }
        public string FileUrlPath { get; set; }
        public int GalleryId { get; set; }
        public TimeSpan? Duration { get; set; }

    }

    public class FileGetModel
    {
        public PhysicalFileResult FilePhysicalPath { get; set; }

        public string FileUrlPath { get; set; }

    }
 
}
