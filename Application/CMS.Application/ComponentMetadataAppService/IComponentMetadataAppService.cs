using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.ComponentAppService.Dto;
using CMS.Application.ComponentMetadataAppService.Dto;
using Infrastructure.Application;
using Sieve.Models;

namespace CMS.Application.ComponentMetadataAppService
{
    public interface IComponentMetadataAppService : IBaseAppService<ComponentMetadataGetDto, ComponentMetadataGetDto, ComponentMetadataCreateDto, ComponentMetadataUpdateDto, SieveModel>
    {
    }
}
