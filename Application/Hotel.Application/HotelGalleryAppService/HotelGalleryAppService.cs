using AutoMapper;
using Gallery.Application.GalleryAppService;
using Gallery.Application.GalleryAppService.Dtos;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Hotel.Application.HotelGalleryAppService.Validations;
using Hotel.Application.RoomAppService.Dtos;
using Hotel.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Hotel.Application.HotelGalleryAppService
{
    public class HotelGalleryAppService : BaseAppService<HotelDbContext, Domain.Models.HotelGallery, HotelGalleryOutputDto, HotelGalleryOutputDto, HotelGalleryCreateDto, HotelGalleryUpdateDto, SieveModel>, IHotelGalleryAppService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HotelDbContext _serviceDbContext;
       
        public HotelGalleryAppService(
            HotelDbContext serviceDbContext, 
            IMapper mapper, 
            ISieveProcessor processor, 
            HotelGalleryValidator validations, 
            IHttpContextAccessor httpContextAccessor) 
            : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }
        public async Task<IEnumerable<HotelGalleryOutputDto>> GetHotelGalleryByHotelIdAsync(int hotelId)
        {
            var HotelGalleries = await _serviceDbContext.HotelGalleries
                .Include(r => r.Hotel)
                .Where(r => r.HotelId == hotelId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<HotelGalleryOutputDto>>(HotelGalleries);
        }
        /*Soon
        public async Task<GalleryGetDto> GetGalleryByGalleryName(string galleryName)
        {
        }
        */
        protected override IQueryable<Domain.Models.HotelGallery> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}