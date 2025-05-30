﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Gallery.Domain.Models
{
    public class File : BasicEntityWithAuditInfo
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public float Size { get; set; }
        public string Path { get; set; }
        public string MimeType { get; set; }
        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }
        public TimeSpan? Duration { get; set; }

        public string? Description { get; set; }

        public string? Caption { get; set; }    

        public string? AlternativeText { get; set; }
        public string? FileUrlPath { get; set; }
        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; } // Navigation property
    }
}
