using AutoMapper;
using HR.Application;
using HR.Application.ApplicationAppService;
using HR.Application.ApplicationAppService.Dtos;
using HR.Application.CandidateAppService;
using HR.Application.CandidateAppService.Dtos;
using HR.Application.CandidateAppService.Validations;
using HR.Application.JobPostAppService;
using HR.Application.JobPostAppService.Dtos;
using HR.Application.JobPostAppService.Processors;
using HR.Application.JobPostAppService.Validations;
using HR.Application.PositionAppService;
using HR.Application.PositionAppService.Dtos;
using HR.Application.PositionAppService.Validations;
using Sieve.Services;

namespace HR.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IJobPostAppService, JobPostAppService>();

            services.AddTransient<JobPostValidator>();

            services.AddTransient<ICandidateAppService, CandidateAppService>();

            services.AddTransient<CandidateValidator>();

            services.AddTransient<IApplicationAppService, ApplicationAppService>();

            services.AddTransient<ApplicationValidator>();


            services.AddTransient<IPositionAppService, PositionAppService>();

            services.AddTransient<PositionValidator>();

            services.AddScoped<ISieveProcessor, HRProcessor>();

            services.AddSingleton<ISieveConfiguration, JobPostProcessorConfiguration>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new JobPostMapperProfile());
                mc.AddProfile(new CandidateMapperProfile());
                mc.AddProfile(new ApplicationMapperProfile());
                mc.AddProfile(new PositionMapperProfile());

            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
