using AutoMapper;
using Gallery.Application;
using Gallery.Application.FileAppservice;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.FileAppservice.Validations;
using Gallery.Application.GalleryAppService;
using Gallery.Application.GalleryAppService.Dtos;
using Gallery.Application.GalleryAppService.Processors;
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

namespace Orchestration.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {


            //Gallery
            services.AddTransient<IGalleryAppService, GalleryAppService>();
            services.AddTransient<IFileAppService, FileAppService>();
            services.AddTransient<GalleryValidator>();
            services.AddTransient<FileValidator>();
            services.AddScoped<ISieveProcessor, GalleryProcessor>();
            //services.AddSingleton<ISieveConfiguration, FileProcessorConfiguration>();
            services.AddSingleton<ISieveConfiguration, GalleryProcessorConfiguration>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GalleryMapperProfile());
                mc.AddProfile(new FileMapperProfile());

                mc.AddProfile(new HotelMapperProfile());
                mc.AddProfile(new HotelGalleryMappingProfile());
                mc.AddProfile(new RoomMappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Hotel
            services.AddTransient<IHotelAppService, HotelAppService>();
            services.AddTransient<IHotelGalleryAppService, HotelGalleryAppService>();
            services.AddTransient<IRoomAppService, RoomAppService>();
            //services.AddTransient<IPOSAppService, POSAppService>();
            // Register Validators
            services.AddTransient<HotelValidator>();
            services.AddTransient<HotelGalleryValidator>();
            services.AddTransient<RoomValidator>();

            services.AddScoped<ISieveProcessor, SieveProcessor>();

            //CW 


        }
    }
}