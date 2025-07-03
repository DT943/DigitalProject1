using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class OTAUser : BasicEntityWithAuditAndFakeDelete
    {
        [Required]
        public string POS { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string EncryptedPassword { get; set; }

    }
}
