using AutoMapper;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.HotelAppService.Validations;
using Hotel.Application.HotelAppService;
using Hotel.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Application.HotelAppService
{
    public class HotelAppService : BaseAppService<HotelDbContext, Domain.Models.Hotel, HotelGetDto, HotelGetDto, HotelCreateDto, HotelUpdateDto, SieveModel>, IHotelAppService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HotelDbContext _serviceDbContext;
        private readonly IMapper _mapper;

        public HotelAppService(
            HotelDbContext serviceDbContext,
            IMapper mapper,
            ISieveProcessor processor,
            HotelValidator validations,
            IHttpContextAccessor httpContextAccessor)
            : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
            _mapper = mapper;
        }
        // Override the Create method to include ContactInfo creation
        public override async Task<HotelGetDto> Create(HotelCreateDto createDto)
        {
            // Map HotelCreateDto to Hotel entity
            var hotel = _mapper.Map<Domain.Models.Hotel>(createDto);

            // Ensure ContactInfo is mapped and associated with the Hotel entity
            if (createDto.ContactInfo != null && createDto.ContactInfo.Any())
            {
                hotel.ContactInfo = _mapper.Map<List<Domain.Models.ContactInfo>>(createDto.ContactInfo);
            }

            // Add the Hotel entity (including ContactInfo) to the context
            _serviceDbContext.Hotels.Add(hotel);

            // Save changes (this will save both Hotel and ContactInfo in a single transaction)
            await _serviceDbContext.SaveChangesAsync();

            // Map the created Hotel entity back to the HotelGetDto and return it
            return _mapper.Map<HotelGetDto>(hotel);

        }
        public override async Task<HotelGetDto> Update(HotelUpdateDto updateDto)
        {
            // Map HotelCreateDto to Hotel entity
            var hotel = _mapper.Map<Domain.Models.Hotel>(updateDto);

            // Ensure ContactInfo is mapped and associated with the Hotel entity
            if (updateDto.ContactInfo != null && updateDto.ContactInfo.Any())
            {
                hotel.ContactInfo = _mapper.Map<List<Domain.Models.ContactInfo>>(updateDto.ContactInfo);
            }

            // Add the Hotel entity (including ContactInfo) to the context
            _serviceDbContext.Hotels.Update(hotel);

            // Save changes (this will save both Hotel and ContactInfo in a single transaction)
            await _serviceDbContext.SaveChangesAsync();

            // Map the created Hotel entity back to the HotelGetDto and return it
            return _mapper.Map<HotelGetDto>(hotel);

        }
        public override async Task<HotelGetDto> Get(int id)
        {
            var hotel = await _serviceDbContext.Hotels
                .Include(h => h.ContactInfo)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (hotel == null)
                return null;

            return _mapper.Map<HotelGetDto>(hotel);
        }
        /*
        public override async Task<IEnumerable<HotelGetDto>> GetAll()
        {
            var hotels = await _serviceDbContext.Hotels
                .Include(h => h.ContactInfo)
                .ToListAsync();

            return _mapper.Map<IEnumerable<HotelGetDto>>(hotels);
        }
        */
        protected override IQueryable<Domain.Models.Hotel> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}