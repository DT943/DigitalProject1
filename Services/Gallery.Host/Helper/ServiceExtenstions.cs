using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Gallery.Application.GalleryAppService;
using Gallery.Application.GalleryAppService.Dtos;
 
using Sieve.Services;
using Gallery.Application.GalleryAppService.Validations;
using Gallery.Application.FileAppservice;
using Gallery.Application.FileAppservice.Validations;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application;

using Gallery.Application.GalleryAppService.Processors;
using Gallery.Application.OCRExternalAppService;


namespace Gallery.Host.Helper
{
    public static class ServiceExtenstions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IGalleryAppService, GalleryAppService>();
            services.AddTransient<IFileAppService, FileAppService>();

            services.AddHttpClient<IOCRExternalAppService, OCRExternalAppService>();

            services.AddTransient<GalleryValidator>();
            services.AddTransient<FileValidator>();


            services.AddScoped<ISieveProcessor, GalleryProcessor>();
            //services.AddSingleton<ISieveConfiguration, FileProcessorConfiguration>();
            services.AddSingleton<ISieveConfiguration, GalleryProcessorConfiguration>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GalleryMapperProfile());
                mc.AddProfile(new FileMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
