﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Gallery.Domain.Models
{
    public class Gallery : BasicEntityWithAuditInfo
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        [MaxLength(50)]
        public string? Type { get; set; }
        public ICollection<File> Files { get; set; } // Collection of files belonging to the gallery
    }
}
