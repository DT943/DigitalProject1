using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class POS : BasicEntityWithAuditAndFakeDelete
    {

        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string POSCode { get; set; }

        public string CurrencyCode {  get; set; }

        public ICollection<POSTranslation> POSTranslations { get; set; }
        public ICollection<OTAUser> OTAUsers { get; set; }
      

    }
}
