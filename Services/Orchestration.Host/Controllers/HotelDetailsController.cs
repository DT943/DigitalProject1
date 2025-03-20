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
        public async Task<ActionResult<HotelGetDetailsDto>> CreateHotelWithDetails([FromBody] HotelCreateDetailsDto hotelCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                /*
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
            */
                // 5. Return complete hotel details
                var result = await GetHotelWithDetails(25);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
 
        [HttpGet("GetHotelWithDetails/{id}")]
        public async Task<ActionResult<HotelGetDetailsDto>> GetHotelWithDetails(int id)
        {
            try
            {
                var hotel = await _hotelAppService.Get(id);
                if (hotel == null)
                    return NotFound($"Hotel with ID {id} not found");

                // Get Contact Info
                var contactInfo = await _serviceDbContext.ContactInfo
                    .Where(x => x.HotelId == hotel.Id)
                    .ToListAsync();

                // Get Rooms
                var rooms = await _serviceDbContext.Rooms
                    .Where(x => x.HotelId == hotel.Id)
                    .ToListAsync();

                // Get Hotel Galleries with their associated files
                var hotelGalleries = await _serviceDbContext.HotelGalleries
                    .Where(x => x.HotelId == hotel.Id)
                    .ToListAsync();

                // Map to DTO
                var hotelDetailsDto = _mapper.Map<HotelGetDetailsDto>(hotel);
                hotelDetailsDto.ContactInfo = _mapper.Map<IEnumerable<ContactInfoGetDto>>(contactInfo);
                hotelDetailsDto.Rooms = _mapper.Map<IEnumerable<RoomOutputDto>>(rooms);
                if (hotelGalleries != null && hotelGalleries.Any())
                {
                    var hotelGalleryDtos = new List<HotelGalleryDetailsOutputDto>();

                    foreach (var gallery in hotelGalleries)
                    {
                        var galleryDto = _mapper.Map<HotelGalleryDetailsOutputDto>(gallery);

                        // Get gallery details including files
                        var galleryDetails = await _galleryAppService.Get(gallery.Id);
                        if (galleryDetails != null)
                        {
                            var files = await _fileAppServicce.GetRelatedFileGallery(gallery.Id);

                            var lightfiles = files.Select(file => new Hotel.Application.HotelGalleryAppService.Dtos.FileGetModel
                            {
                                FileUrlPath = file.FileUrlPath,
                                // FilePhysicalPath = file.Path
                            }).ToList();

                            galleryDto.Files = lightfiles;
                        }

                        hotelGalleryDtos.Add(galleryDto);
                    }

                    hotelDetailsDto.HotelGallery = hotelGalleryDtos;
                }

                return Ok(hotelDetailsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
