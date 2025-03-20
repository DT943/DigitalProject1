using AutoMapper;
using Gallery.Application.GalleryAppService;
using Gallery.Application.GalleryAppService.Dtos;
using Gallery.Application.GalleryAppService.Validations;
using Hotel.Application.HotelAppService;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.HotelAppService.Validations;
using Hotel.Application.HotelGalleryAppService;
using Hotel.Application.HotelGalleryAppService.Mapping;
using Hotel.Application.HotelGalleryAppService.Validations;
using Hotel.Application.RoomAppService;
using Hotel.Application.RoomAppService.Mapping;
using Hotel.Application.RoomAppService.Validations;
using Sieve.Services;

namespace Hotel.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            // Register Services
            services.AddTransient<IHotelAppService, HotelAppService>();
            services.AddTransient<IHotelGalleryAppService, HotelGalleryAppService>();
            services.AddTransient<IRoomAppService, RoomAppService>();

            services.AddTransient<IGalleryAppService, GalleryAppService>();

            // Register Validators
            services.AddTransient<HotelValidator>();
            services.AddTransient<HotelGalleryValidator>();
            services.AddTransient<RoomValidator>();
            services.AddTransient<GalleryValidator>();

            // Register Sieve
            services.AddScoped<ISieveProcessor, SieveProcessor>();

            // Configure AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GalleryMapperProfile());
                mc.AddProfile(new HotelMapperProfile());
                mc.AddProfile(new HotelGalleryMappingProfile());
                mc.AddProfile(new RoomMappingProfile());
            });
            
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}