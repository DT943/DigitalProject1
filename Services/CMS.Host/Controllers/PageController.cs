using CMS.Application.PageAppService;
using CMS.Application.PageAppService.Dtos;
using Infrastructure.Application;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Sieve.Models;

namespace CMS.Host.Controllers
{
    [Authorize]
    public class PageController : BaseController<IPageAppService, Domain.Models.Page, PageGetDto, PageCreateDto, PageUpdateDto, SieveModel>
    {
        IPageAppService _appService;
        public PageController(IPageAppService appService) : base(appService)
        {
            _appService = appService;
        }


    }
}
