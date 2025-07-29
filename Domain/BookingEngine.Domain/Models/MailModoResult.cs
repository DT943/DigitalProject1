using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class MailModoResult : BasicEntity
    {
        public string PNR { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }


        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

    }
}
