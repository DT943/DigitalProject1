using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class AirPortTranslation  

    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LanguageCode { get; set; }

        [Required]
        public int AirPortId {  get; set; }

        [ForeignKey("AirPortId")]
        public AirPort AirPort { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        [StringLength(150)]
        public string AirPortName { get; set; }

    }
}
