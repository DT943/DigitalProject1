using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Hotel.Application.ContractAppService.Dtos
{
    public class ContractCreateDto : IValidatableDto
    {
         public int HotelId { get; set; }
         public string? ContractFileUrl { get; set; }
         public string? ContractFileCode { get; set; }
         public DateTime? StartDate { get; set; }
         public DateTime? EndDate { get; set; }


    }
    public class ContractUpdateDto : IEntityUpdateDto
    {
        public int HotelId { get; set; }
        public string? ContractFileUrl { get; set; }
        public string? ContractFileCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


    }
}
