using AutoMapper;
using BranchesManagement.Application.BranchesManagementAppService;
using BranchesManagement.Application.BranchesManagementAppService.Dto;
using BranchesManagement.Application.BranchesManagementAppService.Validations;


using Sieve.Services;

namespace BranchesManagement.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IBranchesManagementAppService, BranchesManagementAppService>();

            services.AddTransient<BranchesManagementValidator>();

            services.AddScoped<ISieveProcessor, SieveProcessor>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BranchesManagementMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
