using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Application.ContactInfoAppService.Dtos;
using Hotel.Application.HotelAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace Hotel.Application.ContactInfoAppService
{
    public interface IContactInfoAppService: IBaseAppService<ContactInfoGetDto, ContactInfoGetDto, ContactInfoCreateDto, ContactInfoUpdateDto, SieveModel>
    {
    }
}
