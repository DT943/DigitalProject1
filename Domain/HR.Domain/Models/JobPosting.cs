using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace HR.Domain.Models
{
    public class JobPosting : BasicEntityWithAuditInfo
    {

        public string JobTitle { get; set;}
        [MaxLength(100)]
        public string Department { get; set;}
        public string Location { get; set;}
        [MaxLength(50)]
        public string JobType { get; set;}
        [MaxLength(50)]
        public string Status { get; set;}
        public DateTime ClosingDate { get; set;}
        public string Description { get; set;}
        [MaxLength(4000)]
        public string Requirements { get; set;}
        [MaxLength(4000)]
        public string Responsibilities { get; set;}
    }
}
