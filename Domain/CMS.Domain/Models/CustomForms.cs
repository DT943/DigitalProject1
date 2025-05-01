using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace CMS.Domain.Models
{
    public class CustomForm : BasicEntity 
    {
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public string Services { get; set; }

        public int NumberofSubmistion { get; set; }
        public DateTime LastSubmissionDate { get; set; }

    }
}
