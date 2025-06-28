using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class AirPort : BasicEntityWithAuditAndFakeDelete
    {

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string IATACode { get; set; }

        public ICollection<AirPortTranslation> AirPortTranslations { get; set; }

    }
}
