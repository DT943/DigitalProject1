using AutoMapper;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.RoomAppService.Dtos;
using Hotel.Application.RoomAppService.Validations;
using Hotel.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Hotel.Application.RoomAppService
{
    public class RoomAppService : BaseAppService<HotelDbContext, Domain.Models.Room, RoomOutputDto, RoomOutputDto, RoomCreateDto, RoomUpdateDto, SieveModel>, IRoomAppService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HotelDbContext _serviceDbContext;
        private readonly IMapper _mapper;

        public RoomAppService(
            HotelDbContext serviceDbContext,
            IMapper mapper,
            ISieveProcessor processor,
            RoomValidator validations,
            IHttpContextAccessor httpContextAccessor)
            : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
            _mapper = mapper;
        }

        public async Task<List<RoomOutputDto>> GetRoomsByHotelIdAsync(int hotelId)
        {
            var rooms = await _serviceDbContext.Rooms
                .Include(r => r.Hotel)
                .Where(r => r.HotelId == hotelId)
                .ToListAsync();

            return _mapper.Map<List<RoomOutputDto>>(rooms);
        }
    }
}