using CMS.Application.ComponentAppService.Dto;
using CMS.Application.ComponentAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using CMS.Application.ComponentMetadataAppService;
using CMS.Application.ComponentMetadataAppService.Dto;

namespace CMS.Host.Controllers
{
    public class ComponentMetadataController : BaseController<IComponentMetadataAppService, Domain.Models.ComponentMetadata, ComponentMetadataGetDto, ComponentMetadataGetDto, ComponentMetadataCreateDto, ComponentMetadataUpdateDto, SieveModel>
    {
        IComponentMetadataAppService _appService;
        public ComponentMetadataController(IComponentMetadataAppService appService) : base(appService, Servics.CMS)
        {
            _appService = appService;
        }


    }
}
