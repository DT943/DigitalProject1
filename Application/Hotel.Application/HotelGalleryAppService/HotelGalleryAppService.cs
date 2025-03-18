using AutoMapper;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Hotel.Application.HotelGalleryAppService.Validations;
using Hotel.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;

namespace Hotel.Application.HotelGalleryAppService
{
    public class HotelGalleryAppService : BaseAppService<HotelDbContext, Domain.Models.HotelGallery, HotelGalleryOutputDto, HotelGalleryOutputDto, HotelGalleryInputDto, HotelGalleryUpdateDto, SieveModel>, IHotelGalleryAppService
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
    }
}