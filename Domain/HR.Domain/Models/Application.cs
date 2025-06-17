using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace HR.Domain.Models
{
    public class Application : BasicEntityWithAuditAndFakeDelete
    {
        public int CandidateId { get; set; }

        [ForeignKey("CandidateId")]
        public Candidate Candidate { get; set; }


        public int JobPostId { get; set; }

        [ForeignKey("JobPostId")]
        public JobPost JobPost { get; set; }

        public DateTime AppliedDate { get; set; }

    }
}
