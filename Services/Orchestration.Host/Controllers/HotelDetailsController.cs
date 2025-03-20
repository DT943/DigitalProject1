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
        public async Task<ActionResult<HotelGetDetailsDto>> CreateHotelWithDetails([FromForm] HotelCreateDetailsDto hotelCreateDto, IFormFileCollection files)
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

                // 2. Add Contact Info
                if (hotelCreateDto.ContactInfo.Any())
                {
                    var contactInfos = hotelCreateDto.ContactInfo.Select(contactInfoDto =>
                        new ContactInfo
                        {
                            HotelId = createdHotel.Id,
                            PhoneNumber = contactInfoDto.PhoneNumber,
                            Email = contactInfoDto.Email,
                            ResponsiblePerson = contactInfoDto.ResponsiblePerson,
                        }).ToList();

                    _serviceDbContext.ContactInfo.AddRange(contactInfos);
                    await _serviceDbContext.SaveChangesAsync();
                }

                // 3. Add Rooms
                if (hotelCreateDto.Rooms.Any())
                {
                    var rooms = hotelCreateDto.Rooms.Select(roomDto =>
                        new Room
                        {
                            HotelId = createdHotel.Id,
                            Category = roomDto.Category,
                            NumberOfAdults = roomDto.NumberOfAdults,
                            NumberOfChildren = roomDto.NumberOfChildren,
                        }).ToList();

                    _serviceDbContext.Rooms.AddRange(rooms);
                    await _serviceDbContext.SaveChangesAsync();
                }

                // 4. Create Hotel Galleries with Files
                if (hotelCreateDto.HotelGallery.Any() && files != null && files.Any())
                {
                    var fileIndex = 0;
                    foreach (var galleryItem in hotelCreateDto.HotelGallery)
                    {
                        // Create gallery
                        var galleryCreateDto = new GalleryCreateDto
                        {
                            Name = galleryItem.GalleryName ?? $"{galleryItem.GalleryType?.ToLower()}_{createdHotel.Id}",
                            Description = $"{galleryItem.GalleryType} gallery for hotel: {createdHotel.Name}",
                            Type = "hotel"
                        };

                        var gallery = await _galleryAppService.Create(galleryCreateDto);

                        if (gallery != null && fileIndex < files.Count)
                        {
                            var file = files[fileIndex];

                            var fileCreateDto = new FileCreateDto
                            {
                                Title = $"{galleryItem.GalleryName}_{file.FileName}",
                                FileType = Path.GetExtension(file.FileName).TrimStart('.'),
                                GalleryId = gallery.Id,
                                File = file
                            };

                            await _fileAppServicce.Create(fileCreateDto);
                            fileIndex++;

                            // Link gallery to hotel
                            var hotelGallery = new HotelGallery
                            {
                                HotelId = createdHotel.Id,
                                GalleryName = galleryItem.GalleryName,
                                //GalleryCode = gallery.CreatedBy,
                                GalleryType = galleryItem.GalleryType
                            };

                            _serviceDbContext.HotelGalleries.Add(hotelGallery);
                            await _serviceDbContext.SaveChangesAsync();
                        }
                    }
                }

                // 5. Return complete hotel details
                var result = await GetHotelDetails(createdHotel.Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        private async Task<HotelGetDetailsDto> GetHotelDetails(int hotelId)
        {
            var hotel = await _serviceDbContext.Hotels
                .Include(h => h.ContactInfo)
                .Include(h => h.Rooms)
                .Include(h => h.HotelGallery)
                .FirstOrDefaultAsync(h => h.Id == hotelId);

            if (hotel == null)
                return null;

            var hotelDetailsDto = _mapper.Map<HotelGetDetailsDto>(hotel);

            // Map related entities
            hotelDetailsDto.ContactInfo = _mapper.Map<IEnumerable<ContactInfoGetDto>>(hotel.ContactInfo);
            hotelDetailsDto.Rooms = _mapper.Map<IEnumerable<RoomOutputDto>>(hotel.Rooms);
            hotelDetailsDto.HotelGallery = _mapper.Map<IEnumerable<HotelGalleryDetailsOutputDto>>(hotel.HotelGallery);

            return hotelDetailsDto;
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
