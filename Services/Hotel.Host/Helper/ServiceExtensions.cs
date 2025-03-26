using AutoMapper;
using Gallery.Application.FileAppservice;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.FileAppservice.Validations;
using Gallery.Application.GalleryAppService;
using Gallery.Application.GalleryAppService.Dtos;
using Gallery.Application.GalleryAppService.Validations;
using Hotel.Application.ContractAppService;
using Hotel.Application.ContractAppService.Dtos;
using Hotel.Application.ContractAppService.Validations;
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
            services.AddTransient<IFileAppService, FileAppService>();
            services.AddTransient<IContractAppService, ContractAppService>();
 
            // Register Validators
            services.AddTransient<HotelValidator>();
            services.AddTransient<HotelGalleryValidator>();
            services.AddTransient<RoomValidator>();
            services.AddTransient<GalleryValidator>();
            services.AddTransient<FileValidator>();
            services.AddTransient<ContractValidator>();

            // Register Sieve
            services.AddScoped<ISieveProcessor, SieveProcessor>();

            // Configure AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GalleryMapperProfile());
                mc.AddProfile(new FileMapperProfile());
                mc.AddProfile(new HotelMapperProfile());
                mc.AddProfile(new HotelGalleryMappingProfile());
                mc.AddProfile(new RoomMappingProfile());
                mc.AddProfile(new ContractMapperProfile());

            });
            
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}