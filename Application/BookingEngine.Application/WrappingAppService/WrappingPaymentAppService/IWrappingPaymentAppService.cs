using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.WrappingAppService.WrappingPaymentAppService.Dtos;

namespace BookingEngine.Application.WrappingAppService.WrappingPaymentAppService
{
    public interface IWrappingPaymentAppService
    {
        Task<PaymentSystemGetDto> PaymentAsync(PaymentSystemCreateDto inquirePNRRequest);
    }
}
