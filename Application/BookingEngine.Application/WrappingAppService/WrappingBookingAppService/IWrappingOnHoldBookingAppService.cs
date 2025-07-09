using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BookingEngine.Application.WrappingAppService.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos;

namespace BookingEngine.Application.WrappingAppService.WrappingBookingAppService
{
    public interface IWrappingOnHoldBookingAppService
    {

        Task<BookGetDto> OnHoldBookingFlightAsync(BookCreateDto onholdRequest);
    }
}
