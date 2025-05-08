using AutoMapper;
using Gallery.Application.FileAppservice;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.GalleryAppService;
using Gallery.Application.GalleryAppService.Dtos;
using Hotel.Application.ContactInfoAppService.Dtos;
using Hotel.Application.HotelAppService;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Hotel.Application.RoomAppService.Dtos;
using Hotel.Data.DbContext;
using Hotel.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Orchestration.Host.Controllers
{
    [Route("Hotel")]
    [ApiController]
    public class HotelDetailsController : ControllerBase
    {
        private readonly IGalleryAppService _galleryAppService;
        private readonly IFileAppService _fileAppServicce;
        private readonly IHotelAppService _hotelAppService;
        private readonly IMapper _mapper;
        private readonly HotelDbContext _serviceDbContext;

        public HotelDetailsController(
            IGalleryAppService galleryAppService,
            IHotelAppService hotelAppService,
            IFileAppService fileAppServicce,
            IMapper mapper,
            HotelDbContext serviceDbContext)
        {
            _galleryAppService = galleryAppService;
            _hotelAppService = hotelAppService;
            _fileAppServicce = fileAppServicce;
            _mapper = mapper;
            _serviceDbContext = serviceDbContext;
        }

        [HttpPost("/CreateHotelWithDetails")]
        public async Task<ActionResult<HotelGetDetailsDto>> CreateHotelWithDetails([FromBody] HotelCreateDto hotelCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                
                // 1. Create the base hotel
                var hotelCreateBaseDto = _mapper.Map<HotelCreateDto>(hotelCreateDto);
                var createdHotel = await _hotelAppService.Create(hotelCreateBaseDto);

                if (createdHotel == null)
                    return BadRequest("Failed to create hotel");


                // 4. Create Hotel Galleries with Files
                if (hotelCreateDto.HotelGallery.Any() )
                {
                    var fileIndex = 0;
                    foreach (var galleryItem in hotelCreateDto.HotelGallery)
                    {
                        // Create gallery
                        var galleryCreateDto = new GalleryCreateDto
                        {
                            Name = galleryItem.GalleryName.ToLower() ?? $"{galleryItem.GalleryType?.ToLower()}_{createdHotel.Name.ToLower()}",
                            Description = $"{galleryItem.GalleryType.ToLower()} gallery for hotel: {createdHotel.Name.ToLower()}",
                            Type = "hotel"
                        };

                        var gallery = await _galleryAppService.Create(galleryCreateDto);

                        if (gallery != null )
                        {
                            // Link gallery to hotel
                            var hotelGallery = new HotelGallery
                            {
                                HotelId = createdHotel.Id,
                                GalleryName = gallery.Name,
                                GalleryCode = gallery.Code,
                                Code = gallery.Code,
                                CreatedBy= gallery.CreatedBy,
                                CreatedDate = gallery.CreatedDate,
                                GalleryType = gallery.Type
                            };

                            _serviceDbContext.HotelGalleries.Add(hotelGallery);
                            await _serviceDbContext.SaveChangesAsync();
                        }
                    }
                }
            
                // 5. Return complete hotel details
                var result = await _hotelAppService.Get(createdHotel.Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
