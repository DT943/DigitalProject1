using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos;

namespace BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService
{
    public interface IWrappingInquirePNRAppService
    {
        Task<InquirePNRGetDto> InquirePNRAsync(InquirePNRCreateDto inquirePNRRequest);
    }

}
