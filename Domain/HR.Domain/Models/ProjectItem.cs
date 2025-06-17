using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace HR.Domain.Models
{
    public class ProjectItem 
    {
        [Key]
        public int Id { get; set; }

        public int CandidateId { get; set; }

        [ForeignKey("CandidateId")]
        public Candidate Candidate { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [Url]
        public string? Url { get; set; }
    }
}
