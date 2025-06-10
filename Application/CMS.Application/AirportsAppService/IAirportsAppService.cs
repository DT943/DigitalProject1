using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.AirportsAppService.Dto;
using CMS.Application.ComponentAppService.Dto;
using Infrastructure.Application;
using Sieve.Models;

namespace CMS.Application.AirportsAppService
{
    public interface IAirportsAppService : IBaseAppService<AirportsGetDto, AirportsGetDto, AirportsCreateDto, AirportsUpdateDto, SieveModel>
    {
    }
}
