using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.StaticComponentAppService.Dto;
using CMS.Application.TravelUpdatesAppService.Dto;
using Infrastructure.Application;
using Sieve.Models;

namespace CMS.Application.TravelUpdatesAppService
{
    public interface ITravelUpdatesAppService : IBaseAppService<TravelUpdatesGetDto, TravelUpdatesGetDto, TravelUpdatesCreateDto, TravelUpdatesUpdateDto, SieveModel>
    {
    }
}