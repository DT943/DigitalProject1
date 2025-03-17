using CMS.Application.PageAppService;
using CMS.Application.PageAppService.Dtos;
using Infrastructure.Application;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace CMS.Host.Controllers
{
    [Authorize]
    public class PageController : BaseController<IPageAppService, Domain.Models.Page, PageGetDto, PageGetDto, PageCreateDto, PageUpdateDto, SieveModel>
    {
        IPageAppService _appService;
        public PageController(IPageAppService appService) : base(appService)
        {
            _appService = appService;
        }

 
        [HttpGet("/{pos}/{language}/{pageUrlName}")]
        public async Task<ActionResult<PageGetDto>> GetPage(string pos, string language, string pageUrlName)
        {
            return await _appService.GetPageBySubUrl(pos, language, pageUrlName);
        }
        [HttpGet("/get-sub-path/{pos}/{language}/")]
        [HttpGet("/get-sub-path/{pos}/{language}/{*pageUrlName}")]
        public async Task<IEnumerable<PageGetUrl>> GetSubPathsAsync(string pos, string language, string pageUrlName="")
        {
            return await _appService.GetSubPathsAsync(pos, language, pageUrlName);
        }

        [HttpGet("/get-page-by-status")]
        public async Task<IEnumerable<PageGetDto>> GetPageByStatus()
        {
            if (!HttpContext.Request.Headers.TryGetValue("status", out var statusValues))
            {
                return (IEnumerable<PageGetDto>)BadRequest("Missing 'status' header.");
            }

            string status = statusValues.ToString();
            return await _appService.GetPageByStatus(status);
        }

    }
}
