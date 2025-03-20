using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CWCore.Application.POSAppService;
using Gallery.Application.GalleryAppService.Dtos;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.HotelAppService.Validations;
using Hotel.Application.RoomAppService.Dtos;
using Hotel.Data.DbContext;
using Hotel.Domain.Models;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Hotel.Application.HotelAppService
{
    public class HotelAppService : BaseAppService<HotelDbContext, Domain.Models.Hotel, HotelGetDto, HotelGetDto, HotelCreateDto, HotelUpdateDto, SieveModel>, IHotelAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        HotelDbContext _serviceDbContext;

        public HotelAppService(HotelDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, HotelValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }
        protected override IQueryable<Domain.Models.Hotel> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
        /*
        public async Task<IEnumerable<HotelGetDto>> GetAllWithContactInfo(SieveModel input)
        {
            var allHotel = base.GetAll(input).Result;
            foreach (var hotel in allHotel) { 
                var ContactInfo = await _serviceDbContext.ContactInfo.Where(x => x.HotelId == hotel.Id).ToListAsync();
                hotel.ContactInfo = _mapper.Map<IEnumerable<ContactInfoGetDto>>(ContactInfo);
            }
            return allHotel;
        }
        */
        public async Task<HotelGetDetailsDto> GetWithDetal(int id)
        {
            var hotel = await base.Get(id);

            var ContactInfo = await _serviceDbContext.ContactInfo.Where(x => x.HotelId == hotel.Id).ToListAsync();
            hotel.ContactInfo = _mapper.Map<IEnumerable<ContactInfoGetDto>>(ContactInfo);

            var rooms = await _serviceDbContext.Rooms.Where(x => x.HotelId == hotel.Id).ToListAsync();
            var hotelDetailsDto = _mapper.Map<HotelGetDetailsDto>(hotel);  
            hotelDetailsDto.Rooms = _mapper.Map<IEnumerable<RoomOutputDto>>(rooms);
            return hotelDetailsDto;
        }
    }
}
