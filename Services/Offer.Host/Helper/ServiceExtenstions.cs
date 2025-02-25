using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Offer.Application.FlightOfferAppService;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Application.FlightOfferAppService.Validations;
using Offer.Application.OfferAppService;
using Offer.Application.OfferAppService.Dtos;
using Offer.Application.OfferAppService.Validations;
using Sieve.Services;

namespace Offer.Host.Helper
{
    public static class ServiceExtenstions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IOfferAppService, OfferAppService>();
            services.AddTransient<IFlightOfferAppService, FlightOfferAppService>();

            services.AddTransient<OfferValidator>();
            services.AddTransient<FlightOfferValidator>();


            services.AddScoped<ISieveProcessor, SieveProcessor>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new OfferMapperProfile());
                mc.AddProfile(new FlightOfferMapperProfile());


            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
