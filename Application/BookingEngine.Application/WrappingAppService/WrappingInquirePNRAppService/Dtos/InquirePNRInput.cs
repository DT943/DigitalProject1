using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos
{
    public class InquirePNRCreateDto : IValidatableDto
    {

        public string LastName { get; set; }

        public string PNR {  get; set; }


    }


}
