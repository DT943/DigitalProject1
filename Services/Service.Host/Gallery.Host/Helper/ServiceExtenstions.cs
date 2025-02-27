using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Gallery.Application.GalleryAppService;
using Gallery.Application.GalleryAppService.Dtos;
 
using Sieve.Services;
using Gallery.Application.GalleryAppService.Validations;



namespace Gallery.Host.Helper
{
    public static class ServiceExtenstions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IGalleryAppService, GalleryAppService>();
 
            services.AddTransient<GalleryValidator>();
 

            services.AddScoped<ISieveProcessor, SieveProcessor>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GalleryMapperProfile());
 

            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
