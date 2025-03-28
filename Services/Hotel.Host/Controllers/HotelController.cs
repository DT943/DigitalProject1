using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.GalleryAppService;
using Hotel.Application.HotelAppService;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Hotel.Host.Controllers
{
    [Authorize]
    public class HotelController : BaseController<IHotelAppService, Domain.Models.Hotel, HotelGetAllDto, HotelGetDto, HotelCreateDto, HotelUpdateDto, SieveModel>
    {
        IHotelAppService _hotelAppService;
         public HotelController(IHotelAppService hotelAppService) : base(hotelAppService, "Hotel")
        {
            _hotelAppService = hotelAppService;
        }

        public override async Task<ActionResult<HotelGetDto>> Create(HotelCreateDto dto)
        {
            return await base.Create(dto);
        }

        [RequestSizeLimit(1_000_000_000)] // 1GB
        [RequestFormLimits(MultipartBodyLengthLimit = 1_000_000_000)]
        [HttpPost("MakeContract")]
        public async Task<IActionResult> MakeContract(ContractCreateDto contractCreateDto)
        {
            if (!UserHasPermission("Admin", "Manager", "Supervisor"))
            {
                return Forbid();
            }
            try
            {
                var file = await _appService.MakeContract(contractCreateDto);
                if (file == null)
                {
                    return NotFound();
                }
                return Ok(file);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating file");
            }
        }


    }
}
