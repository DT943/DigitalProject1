using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace HR.Domain.Models
{
    public class JobPosting : BasicEntityWithAuditInfo
    {
        public string JobTitle { get; set;}
        public string Department { get; set;}
        public string Location { get; set;}
        public string JobType { get; set;}
        public string Status { get; set;}
        public DateTime ClosingDate { get; set;}
        public string Description { get; set;}
        public string Requirements { get; set;}
        public string Responsibilities { get; set;}
    }
}
