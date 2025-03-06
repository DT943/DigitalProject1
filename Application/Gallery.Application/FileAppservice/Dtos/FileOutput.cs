using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gallery.Application.FileAppservice.Dtos
{
    public class FileGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public long Size { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }
        public TimeSpan? UploadedOn { get; set; }
        public string UploadedBy { get; set; }
        public string FileTilte { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Length { get; set; }
        public string Metadata { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public string? Caption { get; set; }
        public string? AlternativeText { get; set; }
        public PhysicalFileResult FilePhysicalPath { get; set; }
        public string FileUrlPath { get; set; }
        public string? Description { get; set; }

        public int GalleryId { get; set; }


    }

    public class FileGetModel
    {
        public PhysicalFileResult FilePhysicalPath { get; set; }

        public string FileUrlPath { get; set; }

    }
}
