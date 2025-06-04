using Authentication.Application;
using Authentication.Application.Dtos;
using Authentication.Application.Processors;
using Authentication.Data.DbContext;
using Authentication.Domain.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Notification.Application;
using Sieve.Services;

namespace Authentication.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            services.AddScoped<IDepartmentAppService, DepartmentAppService>();
            services.AddScoped<IValidator<CreateDepartmentDto>, Application.validator.CreateDepartmentDtoValidator>();



            services.AddScoped<IEmailAppService, EmailAppService>();
            services.AddScoped<ISieveProcessor, SieveProcessor>();
            services.AddScoped<ISieveProcessor, AuthenticationProcessor>();
            services.AddSingleton<ISieveConfiguration, AuthenticationProcessorConfiguration>();

            services.AddHttpClient();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AuthenticationMapperProfile());
                mc.AddProfile(new DepartmentMapperProfile());

            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
