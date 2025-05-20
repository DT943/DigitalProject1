using AutoMapper;
using B2B.Application.TravelAgentApplicationAppService;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using B2B.Application.TravelAgentApplicationAppService.Validations;
using B2B.Application.TravelAgentOffice;
using B2B.Application.TravelAgentOffice.Dto;
using B2B.Application.TravelAgentOffice.Validations;
using CWCore.Application.POSAppService.Validations;
using CWCore.Application.POSAppService;
using Sieve.Services;
using CWCore.Application.POSAppService.Dtos;
using Microsoft.AspNetCore.Authentication;
using Authentication.Application;
using Notification.Application;
using Authentication.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Authentication.Data.DbContext;
using Authentication.Application.Dtos;
using B2B.Application.TravelAgentEmployeeAppService;
using B2B.Application.TravelAgentEmployeeAppService.Validations;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Application.ReservationAppService;
using B2B.Application.ReservationAppService.Validations;
using B2B.Application.ReservationAppService.Dto;

namespace B2B.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IReservationAppService, ReservationAppService>();
            services.AddTransient<ReservationValidator>();

            services.AddTransient<ITravelAgentOfficeAppService, TravelAgentOfficeAppService>();
            services.AddTransient<TravelAgentOfficeValidator>();

            services.AddTransient<ITravelAgentApplicationAppService, TravelAgentApplicationAppService>();
            services.AddTransient<TravelAgentApplicationValidator>();

            services.AddTransient<ITravelAgentEmployeeAppService, TravelAgentEmployeeAppService>();
            services.AddTransient<TravelAgentEmployeeValidator>();


            services.AddTransient<IPOSAppService, POSAppService>();
            services.AddTransient<POSValidator>();

            services.AddScoped<ISieveProcessor, SieveProcessor>();
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            services.AddScoped<IEmailAppService, EmailAppService>();

            services.AddHttpClient();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ReservationMapperProfile());
                mc.AddProfile(new TravelAgentOfficeMapperProfile());
                mc.AddProfile(new TravelAgentApplicationMapperProfile());
                mc.AddProfile(new TravelAgentEmployeeMapperProfile());
                mc.AddProfile(new POSMapperProfile());
                mc.AddProfile(new AuthenticationMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
