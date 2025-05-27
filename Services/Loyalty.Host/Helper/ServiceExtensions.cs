using Authentication.Application;
using Authentication.Data.DbContext;
using Authentication.Domain.Models;
using AutoMapper;
using AutoMapper.Execution;
using Loyalty.Application.MemberAccrualTransactions;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Loyalty.Application.MemberAccrualTransactions.Validations;
using Loyalty.Application.MemberAddressDetailsAppService;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService.Validations;
using Loyalty.Application.MemberContactPersonsAppService;
using Loyalty.Application.MemberContactPersonsAppService.Dtos;
using Loyalty.Application.MemberContactPersonsAppService.Validations;
using Loyalty.Application.MemberDemographicsAndProfileAppService;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Validations;
using Loyalty.Application.MemberEducationalDetailsAppService;
using Loyalty.Application.MemberEducationalDetailsAppService.Dto;
using Loyalty.Application.MemberEducationalDetailsAppService.Validations;
using Loyalty.Application.MemberHobbiesDetailsAppService;
using Loyalty.Application.MemberHobbiesDetailsAppService.Dto;
using Loyalty.Application.MemberHobbiesDetailsAppService.Validations;
using Loyalty.Application.MemberPreferenceDetailsAppService;
using Loyalty.Application.MemberPreferenceDetailsAppService.Dto;
using Loyalty.Application.MemberPreferenceDetailsAppService.Validations;
using Loyalty.Application.MemberSecurityQuestionsAppService;
using Loyalty.Application.MemberSecurityQuestionsAppService.Dto;
using Loyalty.Application.MemberSecurityQuestionsAppService.Validations;
using Loyalty.Application.MemberTelephoneDetailsAppService;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;
using Loyalty.Application.MemberTelephoneDetailsAppService.Validations;
using Loyalty.Application.MemberTravelAgentDetailsAppService;
using Loyalty.Application.MemberTravelAgentDetailsAppService.Dto;
using Loyalty.Application.MemberTravelAgentDetailsAppService.Validations;
using Loyalty.Application.SegmentMilesAppService;
using Loyalty.Application.SegmentMilesAppService.Dto;
using Loyalty.Application.SegmentMilesAppService.Validations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Notification.Application;
using Sieve.Services;

namespace Loyalty.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IMemberAccrualTransactionsAppService, MemberAccrualTransactionsAppService>();
            services.AddTransient<MemberAccrualTransactionsValidator>();

            services.AddTransient<IMemberAddressDetailsAppService, MemberAddressDetailsAppService>();
            services.AddTransient<MemberAddressDetailsValidator>();

            services.AddTransient<IMemberDemographicsAndProfileAppService, MemberDemographicsAndProfileAppService>();
            services.AddTransient<MemberDemographicsAndProfileValidator>();

            services.AddTransient<IMemberTelephoneDetailsAppService, MemberTelephoneDetailsAppService>();
            services.AddTransient<MemberTelephoneDetailsValidator>();

            services.AddTransient<IMemberContactPersonsAppService, MemberContactPersonsAppService>();
            services.AddTransient<MemberContactPersonsValidator>();

            services.AddTransient<IMemberPreferenceDetailsAppService, MemberPreferenceDetailsAppService>();
            services.AddTransient<MemberPreferenceDetailsValidator>();

            services.AddTransient<IMemberHobbiesDetailsAppService, MemberHobbiesDetailsAppService>();
            services.AddTransient<MemberHobbiesDetailsValidator>();

            services.AddTransient<IMemberSecurityQuestionsAppService, MemberSecurityQuestionsAppService>();
            services.AddTransient<MemberSecurityQuestionsValidator>();

            services.AddTransient<IMemberEducationalDetailsAppService, MemberEducationalDetailsAppService>();
            services.AddTransient<MemberEducationalDetailsValidator>();

            services.AddTransient<IMemberTravelAgentDetailsAppService, MemberTravelAgentDetailsAppService>();
            services.AddTransient<MemberTravelAgentDetailsValidator>();
            //MemberTravelAgentDetails
            services.AddTransient<ISegmentMilesAppService, SegmentMilesAppService>();
            services.AddTransient<SegmentMilesValidator>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            services.AddScoped<IEmailAppService, EmailAppService>();



            services.AddScoped<ISieveProcessor, SieveProcessor>();
            services.AddHttpClient();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MemberAddressDetailsMapperProfile());
                mc.AddProfile(new MemberDemographicsAndProfileMapperProfile());
                mc.AddProfile(new MemberTelephoneDetailsMapperProfile());
                mc.AddProfile(new MemberContactPersonsMapperProfile());
                mc.AddProfile(new MemberPreferenceDetailsMapperProfile());
                mc.AddProfile(new MemberHobbiesDetailsMapperProfile());
                mc.AddProfile(new MemberSecurityQuestionsMapperProfile());
                mc.AddProfile(new MemberEducationalDetailsMapperProfile());
                mc.AddProfile(new MemberTravelAgentDetailsMapperProfile());
                mc.AddProfile(new MemberAccrualTransactionsMapperProfile());
                mc.AddProfile(new SegmentMilesMapperProfile());

            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
