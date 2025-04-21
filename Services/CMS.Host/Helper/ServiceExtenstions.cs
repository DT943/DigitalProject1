using AutoMapper;
using CMS.Application.ComponentAppService;
using CMS.Application.ComponentAppService.Dto;
using CMS.Application.ComponentAppService.Validations;
using CMS.Application.ComponentMetadataAppService;
using CMS.Application.ComponentMetadataAppService.Dto;
using CMS.Application.ComponentMetadataAppService.Validations;
using CMS.Application.CustomFormAppService;
using CMS.Application.CustomFormAppService.Dto;
using CMS.Application.CustomFormAppService.Validations;
using CMS.Application.PageAppService;
using CMS.Application.PageAppService.Dtos;
using CMS.Application.PageAppService.Validations;
using CMS.Application.SegmentAppService;
using CMS.Application.SegmentAppService.Dtos;
using CMS.Application.SegmentAppService.Validations;
using CMS.Application.StaticComponentAppService;
using CMS.Application.StaticComponentAppService.Dto;
using CMS.Application.StaticComponentAppService.Validations;
using CMS.Domain.Models;
using CWCore.Application.POSAppService;
using CWCore.Application.POSAppService.Dtos;
using CWCore.Application.POSAppService.Validations;
using Sieve.Services;

namespace CMS.Host.Helper
{
    public static class ServiceExtenstions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IPageAppService, PageAppService>();
            services.AddTransient<PageValidator>();

            services.AddTransient<ISegmentAppService, SegmentAppService>();
            services.AddTransient<SegmentValidator>();

            services.AddTransient<IComponentAppService, ComponentAppService>();
            services.AddTransient<ComponentValidator>();

            services.AddTransient<IComponentMetadataAppService, ComponentMetadataAppService>();
            services.AddTransient<ComponentMetadataValidator>();

            services.AddTransient<IStaticComponentAppService, StaticComponentAppService>();
            services.AddTransient<StaticComponentValidator>();


            services.AddTransient<IPOSAppService, POSAppService>();
            services.AddTransient<POSValidator>();

            services.AddTransient<ICustomFormAppService, CustomFormAppService>();
            services.AddTransient<CustomFormValidator>();

            services.AddScoped<ISieveProcessor, SieveProcessor>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PageMapperProfile());
                mc.AddProfile(new SegmentMapperProfile());
                mc.AddProfile(new ComponentMapperProfile());
                mc.AddProfile(new ComponentMetadataMapperProfile());
                mc.AddProfile(new StaticComponentMapperProfile());
                mc.AddProfile(new POSMapperProfile());
                mc.AddProfile(new CustomFormMapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
