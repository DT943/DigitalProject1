using BookingEngine.Application.AuditAppService;
using BookingEngine.Application.AuditAppService.Dtos;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace BookingEngine.Host.Controllers
{
    public class SearchRequestController : BaseController<ISearchRequestAppService, Domain.Models.SearchRequest, SearchRequestGetDto, SearchRequestGetDto, SearchRequestCreateDto, SearchRequestUpdateDto, SieveModel>
    {
        public SearchRequestController(ISearchRequestAppService appService) : base(appService, Servics.BookingEngine)
        {

        }

        [AllowAnonymous]
        [HttpPost]
        public override async Task<ActionResult<SearchRequestGetDto>> Create(SearchRequestCreateDto dto)
        {
            var entity = await _appService.Create(dto);
            return Ok(entity);
        }


    }
}
