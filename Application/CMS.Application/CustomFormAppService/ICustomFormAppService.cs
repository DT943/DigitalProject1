using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.ComponentMetadataAppService.Dto;
using CMS.Application.CustomFormAppService.Dto;
using Infrastructure.Application;
using Sieve.Models;

namespace CMS.Application.CustomFormAppService
{
    public interface ICustomFormAppService : IBaseAppService<CustomFormGetDto, CustomFormGetDto, CustomFormCreateDto, CustomFormUpdateDto, SieveModel>
    {
    }
}
