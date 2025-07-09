using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.POSAppService.Dtos;
using BookingEngine.Domain.Models;

namespace BookingEngine.Application.OTAUserAppService.Dtos
{
    public class OTAUserGetDto
    {
        public int Id { get; set; }

        [Required]
        public int POSId { get; set; }

        [Required]
        public POSGetDto POS { get; set; }


        [Required]
        public string UserName { get; set; }

        [Required]
        public string EncryptedPassword { get; set; }
        [Required]
        public string CompanyName { get; set; }

        public bool IsDeleted { get; set; }

    }
    public class POSGetDto
    {

        public string POSCode { get; set; }

    }

}
