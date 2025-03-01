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



namespace Gallery.Host.Helper
{
    public static class ServiceExtenstions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IGalleryAppService, GalleryAppService>();
            services.AddTransient<IFileAppService, FileAppService>();

            services.AddTransient<GalleryValidator>();
            services.AddTransient<FileValidator>();


            services.AddScoped<ISieveProcessor, SieveProcessor>();
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
