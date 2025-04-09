using AutoMapper;
using HR.Application.JobPostAppService;
using HR.Application.JobPostAppService.Dtos;
using HR.Application.JobPostAppService.Validations;
using Sieve.Services;

namespace HR.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IJobPostAppService, JobPostAppService>();

            services.AddTransient<JobPostValidator>(); 

            services.AddScoped<ISieveProcessor, SieveProcessor>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new JobPostMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
