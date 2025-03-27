using CMS.Application.ComponentAppService.Dto;
using CMS.Application.ComponentAppService;
using Infrastructure.Service.Controllers;
using Sieve.Models;
using CWCore.Application.POSAppService;
using CWCore.Application.POSAppService.Dtos;

namespace CMS.Host.Controllers
{
    public class POSController : BaseController<IPOSAppService, CWCore.Domain.Models.POS, POSGetDto, POSGetDto, POSCreateDto, POSUpdateDto, SieveModel>
    {
        IPOSAppService _appService;
        public POSController(IPOSAppService appService) : base(appService, "CMS")
        {
            _appService = appService;
        }


    }
}
