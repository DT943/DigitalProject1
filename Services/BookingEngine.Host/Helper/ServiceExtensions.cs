using AutoMapper;
using BookingEngine.Application.AirPortAppService;
using BookingEngine.Application.AirPortAppService.Dtos;
using BookingEngine.Application.AirPortAppService.Validations;
using BookingEngine.Application.AuditAppService;
using BookingEngine.Application.AuditAppService.Dtos;
using BookingEngine.Application.AuditAppService.Validations;
using BookingEngine.Application.Filters;
using BookingEngine.Application.OTAUserAppService;
using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.OTAUserAppService.Validations;
using BookingEngine.Application.OTAUserService;
using BookingEngine.Application.PassengerInfo;
using BookingEngine.Application.PassengerInfo.Dtos;
using BookingEngine.Application.PassengerInfo.Validations;
using BookingEngine.Application.PaymantAppService;
using BookingEngine.Application.PaymantAppService.Dtos;
using BookingEngine.Application.PaymantAppService.Validations;
using BookingEngine.Application.POSAppService;
using BookingEngine.Application.POSAppService.Dtos;
using BookingEngine.Application.POSAppService.Validations;
using BookingEngine.Application.Reservation;
using BookingEngine.Application.ReservationInfo;
using BookingEngine.Application.ReservationInfo.Dtos;
using BookingEngine.Application.ReservationInfo.Validations;
using BookingEngine.Application.Services;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Validations;
using BookingEngine.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sieve.Services;

namespace BookingEngine.Host.Helper
{


    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IAirPortAppService, AirPortAppService>();
            services.AddTransient<AirPortValidator>();
            services.AddTransient<ISearchRequestAppService, SearchRequestAppService>();
            services.AddTransient<SearchRequestValidator>();
         
            services.AddTransient<IOTAUserAppService, OTAUserAppService>();
            services.AddTransient<OTAUserValidator>();



            services.AddTransient<IContactInfoAppService, ContactInfoAppService>();
            services.AddTransient<ContactInfoValidator>();

            services.AddTransient<IStripeResultAppService, StripeResultAppService>();
            services.AddTransient<StripeResultValidator>();



            services.AddTransient<IReservationAppService, ReservationAppService>();
            services.AddTransient<ReservationValidator>();



            services.AddTransient<IPOSAppService, POSAppService>();
            services.AddTransient<POSValidator>();

            services.AddScoped<IWrappingOnHoldBookingAppService, WrappingOnHoldBookingAppService>();
         
            services.AddScoped<IWrappingInquirePNRAppService, WrappingInquirePNRAppService>();
            services.AddTransient<InquirePNRValidator>();

            services.AddScoped<IEncryptionAppService, EncryptionAppService>();
            

            services.AddScoped<ISieveProcessor, BookingEngineFilters>();
            services.AddSingleton<ISieveConfiguration, BookingEngineFiltersConfiguration>();

            services.AddScoped<IPaymentAppService, PaymentAppService>();

            

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AirPortMapperProfile());
                mc.AddProfile(new SearchRequestMapperProfile());
                mc.AddProfile(new OTAUserMapperProfile());
                mc.AddProfile(new ReservationInfoMapperProfile());
                mc.AddProfile(new POSMapperProfile());
                mc.AddProfile(new StripeResultMapperProfile());


            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            //services.AddScoped<ISieveProcessor, SieveProcessor>();

        }
    }


}
