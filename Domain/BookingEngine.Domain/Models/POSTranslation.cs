using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Domain.Models
{
    public class POSTranslation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LanguageCode { get; set; }

        [Required]
        public int POSId { get; set; }

        [ForeignKey("POSId")]
        public POS POS { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
