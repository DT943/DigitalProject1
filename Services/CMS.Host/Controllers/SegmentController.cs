using CMS.Application.PageAppService.Dtos;
using CMS.Application.PageAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Sieve.Models;
using CMS.Application.SegmentAppService.Dtos;
using CMS.Application.SegmentAppService;
using static Infrastructure.Domain.Consts;

namespace CMS.Host.Controllers
{
    [Authorize]
    public class SegmentController : BaseController<ISegmentAppService, Domain.Models.Segment, SegmentGetDto, SegmentGetDto, SegmentCreateDto, SegmentUpdateDto, SieveModel>
    {
        ISegmentAppService _appService;
        public SegmentController(ISegmentAppService appService) : base(appService, Servics.CMS)
        {
            _appService = appService;
        }


    }
}
