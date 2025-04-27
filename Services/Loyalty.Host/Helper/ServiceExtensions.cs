using AutoMapper;
using Loyalty.Application.MemberAddressDetailsAppService;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService.Validations;
using Loyalty.Application.MemberDemographicsAndProfileAppService;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Validations;
using Loyalty.Application.MemberTelephoneDetailsAppService;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;
using Loyalty.Application.MemberTelephoneDetailsAppService.Validations;
using Sieve.Services;

namespace Loyalty.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {

            services.AddTransient<IMemberAddressDetailsAppService, MemberAddressDetailsAppService>();
            services.AddTransient<MemberAddressDetailsValidator>();

            services.AddTransient<IMemberDemographicsAndProfileAppService, MemberDemographicsAndProfileAppService>();
            services.AddTransient<MemberDemographicsAndProfileValidator>();

            services.AddTransient<IMemberTelephoneDetailsAppService, MemberTelephoneDetailsAppService>();
            services.AddTransient<MemberTelephoneDetailsValidator>();

            services.AddScoped<ISieveProcessor, SieveProcessor>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MemberAddressDetailsMapperProfile());
                mc.AddProfile(new MemberDemographicsAndProfileMapperProfile());
                mc.AddProfile(new MemberTelephoneDetailsMapperProfile());

            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
