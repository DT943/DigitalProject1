using CMS.Application.PageAppService.Dtos;
using CMS.Application.PageAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Sieve.Models;
using CMS.Application.SegmentAppService.Dtos;
using CMS.Application.SegmentAppService;

namespace CMS.Host.Controllers
{
    [Authorize]
    public class SegmentController : BaseController<ISegmentAppService, Domain.Models.Segment, SegmentGetDto, SegmentCreateDto, SegmentUpdateDto, SieveModel>
    {
        ISegmentAppService _appService;
        public SegmentController(ISegmentAppService appService) : base(appService)
        {
            _appService = appService;
        }


    }
}
