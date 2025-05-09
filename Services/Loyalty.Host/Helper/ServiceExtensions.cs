﻿using AutoMapper;
using AutoMapper.Execution;
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
            services.AddScoped<ISieveProcessor, SieveProcessor>();

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

            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
