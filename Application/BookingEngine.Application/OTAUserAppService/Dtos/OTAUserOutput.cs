using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.OTAUserAppService.Dtos
{
    public class OTAUserGetDto
    {
        public int Id { get; set; }

        [Required]
        public string POS { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string EncryptedPassword { get; set; }
    }
}
