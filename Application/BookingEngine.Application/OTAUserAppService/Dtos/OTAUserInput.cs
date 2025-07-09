using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;
using Infrastructure.Domain.Models;

namespace BookingEngine.Application.OTAUserAppService.Dtos
{
    public class OTAUserCreateDto : IValidatableDto
    {
        [Required]
        public int POSId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string CompanyName { get; set; }

    }

    public class OTAUserUpdateDto: IEntityUpdateDto
    {
        [Required]
        public int POSId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string CompanyName { get; set; }

    }

}
