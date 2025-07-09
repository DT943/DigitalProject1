using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class OTAUser : BasicEntityWithAuditAndFakeDelete
    {
        
        public int POSId {  get; set; }
        [Required]
        [ForeignKey("POSId")]

        public POS POS { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string EncryptedPassword { get; set; }

        [Required]
        public string CompanyName { get; set; }
    }
}
