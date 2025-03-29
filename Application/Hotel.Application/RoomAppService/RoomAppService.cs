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
using Gallery.Application.FileAppservice.Dtos;
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
            return await base.Create(create);
        }

        protected override IQueryable<Domain.Models.Room> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }


    }
}