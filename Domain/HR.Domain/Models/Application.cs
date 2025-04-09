using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace HR.Domain.Models
{
    public class Application : BasicEntity
    {
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }


        [ForeignKey("JobPost")]
        public int JobPostId { get; set; }
        public JobPost JobPost { get; set; }

        public DateTime AppliedDate { get; set; }

    }
}
