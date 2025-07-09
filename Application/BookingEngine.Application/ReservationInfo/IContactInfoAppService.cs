using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.ReservationInfo.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace BookingEngine.Application.ReservationInfo
{
    public interface IContactInfoAppService: IBaseAppService<ContactInfoGetDto, ContactInfoGetDto, ContactInfoCreateDto, ContactInfoUpdateDto, SieveModel>
    {
    }

}
