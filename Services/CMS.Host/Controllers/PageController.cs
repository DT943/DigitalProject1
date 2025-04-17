using CMS.Application.PageAppService;
using CMS.Application.PageAppService.Dtos;
using Infrastructure.Application;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace CMS.Host.Controllers
{
    [Authorize]
    public class PageController : BaseController<IPageAppService, Domain.Models.Page, PageGetDto, PageGetDto, PageCreateDto, PageUpdateDto, SieveModel>
    {
        IPageAppService _appService;
     
        public PageController(IPageAppService appService) : base(appService, Servics.CMS)
        {
            _appService = appService;
        }
        [HttpGet("/{pos}/{language}/{pageUrlName}")]
        [AllowAnonymous]

        public async Task<ActionResult<PageGetDto>> GetPage(string pos, string language, string pageUrlName)
        {
            return await _appService.GetPageBySubUrl(pos, language, pageUrlName);
        }
        [HttpGet("/get-sub-path/{pos}/{language}/")]
        [HttpGet("/get-sub-path/{pos}/{language}/{*pageUrlName}")]
        public async Task<ActionResult<IEnumerable<PageGetUrl>>> GetSubPathsAsync(string pos, string language, string pageUrlName="")
        { 
            return Ok(await _appService.GetSubPathsAsync(pos, language, pageUrlName));
        }

        [HttpGet("/get-page-by-status")]
        public async Task<ActionResult<IEnumerable<PageGetDto>>> GetPageByStatus()
        {
            var user = HttpContext.User;

            if (!UserHasPermission("Admin", "Manager", "Supervisor", "Officer"))
            {
                return Forbid();
            }

            if (!HttpContext.Request.Headers.TryGetValue("status", out var statusValues))
            {
                return BadRequest("Missing 'status' header.");
            }

            string status = statusValues.ToString();
            return Ok(await _appService.GetPageByStatus(status));
        }

    }
}
