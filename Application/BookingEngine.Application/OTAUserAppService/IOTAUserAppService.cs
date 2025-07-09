using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.OTAUserAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace BookingEngine.Application.OTAUserAppService
{
    public interface IOTAUserAppService: IBaseAppService<OTAUserGetDto, OTAUserGetDto, OTAUserCreateDto, OTAUserUpdateDto, SieveModel>
    {

    }
    
}

