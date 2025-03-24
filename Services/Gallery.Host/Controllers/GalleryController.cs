using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.GalleryAppService;
using Gallery.Application.GalleryAppService.Dtos;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Gallery.Host.Controllers
{
    [Authorize]
    public class GalleryController : BaseController<IGalleryAppService, Domain.Models.Gallery, GalleryGetDto, GalleryGetDto, GalleryCreateDto, GalleryUpdateDto, SieveModel>
    {
        IGalleryAppService _appService;
        public GalleryController(IGalleryAppService appService) : base(appService)
        {
            this.ServiceName = "Gallery";
            _appService = appService;
        }


        [HttpGet("getby-galleryName/{galleryName}")]
        public virtual async Task<ActionResult<GalleryGetDto>> GetGalleryByName(string galleryName)
        {
            var gallery = await _appService.GetByName(galleryName);
            return Ok(gallery);
        }

    }
}
