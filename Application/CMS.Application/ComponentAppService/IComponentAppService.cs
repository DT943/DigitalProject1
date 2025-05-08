using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.ComponentAppService.Dto;
using CMS.Application.ComponentMetadataAppService.Dto;
using CMS.Application.PageAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace CMS.Application.ComponentAppService
{
    public interface IComponentAppService : IBaseAppService<ComponentGetDto, ComponentGetDto, ComponentCreateDto, ComponentUpdateDto, SieveModel>
    {
    }
}
