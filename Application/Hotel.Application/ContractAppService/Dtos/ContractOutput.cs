using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.ContractAppService.Dtos
{
    public class ContractGetDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string? ContractFileUrl { get; set; }
        public string? ContractFileCode { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
