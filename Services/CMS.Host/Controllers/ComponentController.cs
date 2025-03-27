using CMS.Application.PageAppService.Dtos;
using CMS.Application.PageAppService;
using Infrastructure.Service.Controllers;
using Sieve.Models;
using CMS.Application.ComponentAppService;
using CMS.Application.ComponentAppService.Dto;

namespace CMS.Host.Controllers
{
    public class ComponentController : BaseController<IComponentAppService, Domain.Models.Component, ComponentGetDto, ComponentGetDto, ComponentCreateDto, ComponentUpdateDto, SieveModel>
    {
        IComponentAppService _appService;
        public ComponentController(IComponentAppService appService) : base(appService,"CMS")
        {
            _appService = appService;
        }


    }
}
