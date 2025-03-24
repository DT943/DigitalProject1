using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Gallery.Application.FileAppservice;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.RoomAppService.Dtos;
using Hotel.Application.RoomAppService.Validations;
using Hotel.Data.DbContext;
using Hotel.Domain.Models;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using FluentValidation;
namespace Hotel.Application.RoomAppService
{
    public class RoomAppService : BaseAppService<HotelDbContext, Domain.Models.Room, RoomOutputDto, RoomOutputDto, RoomCreateDto, RoomUpdateDto, SieveModel>, IRoomAppService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HotelDbContext _serviceDbContext;
        private readonly IFileAppService _fileAppService;
        private readonly IMapper _mapper;

        public RoomAppService(
            HotelDbContext serviceDbContext,
            IMapper mapper,
            ISieveProcessor processor,
            IFileAppService fileAppService,
            RoomValidator validations,
            IHttpContextAccessor httpContextAccessor)
            : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
            _fileAppService = fileAppService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomOutputDto>> GetRoomsByHotelIdAsync(int hotelId)
        {
            var rooms = await _serviceDbContext.Rooms
                .Where(r => r.HotelId == hotelId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<RoomOutputDto>>(rooms);
        }

        public override async Task<RoomOutputDto> Create(RoomCreateDto create)
        {
            var validationResult = await _validations.ValidateAsync(create, options => options.IncludeRuleSets("create", "default"));
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            // Get hotel and its galleries
            var hotel = await _serviceDbContext.Hotels
                .Include(h => h.HotelGallery)
                .FirstOrDefaultAsync(h => h.Id == create.HotelId);

            if (hotel == null)
            {
                throw new FluentValidation.ValidationException($"Hotel with ID {create.HotelId} not found");
            }

            // Get the appropriate gallery code based on room type
            var galleryType ="hotel";
            var galleryCode = hotel.HotelGallery
                .FirstOrDefault(g => g.GalleryName.EndsWith(create.RoomTypeName=="single"? "room-single" : "room-double"))?.GalleryCode;

            if (string.IsNullOrEmpty(galleryCode))
            {
                throw new FluentValidation.ValidationException($"Gallery for {galleryType} not found in hotel {hotel.Name}");
            }
            
            // Assign gallery code to the room
            create.Image.GalleryCode = galleryCode;

            // Create file if image is provided
            if (create.Image != null)
            {
               var createdFile = await _fileAppService.Create(create.Image);
               create.ImageCode = createdFile.Code;
               create.ImageUrlPath = createdFile.FileUrlPath;

            }
            
            return await base.Create(create);
        }

        protected override IQueryable<Domain.Models.Room> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }


    }
}