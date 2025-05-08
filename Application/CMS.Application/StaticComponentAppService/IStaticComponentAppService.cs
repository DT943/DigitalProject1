using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.ComponentAppService.Dto;
using CMS.Application.StaticComponentAppService.Dto;
using Infrastructure.Application;
using Sieve.Models;

namespace CMS.Application.StaticComponentAppService
{
    public interface IStaticComponentAppService : IBaseAppService<StaticComponentGetDto, StaticComponentGetDto, StaticComponentCreateDto, StaticComponentUpdateDto, SieveModel>
    {
    }
}