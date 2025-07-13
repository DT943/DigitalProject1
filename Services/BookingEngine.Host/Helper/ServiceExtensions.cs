using AutoMapper;
using BookingEngine.Application.AirPortAppService;
using BookingEngine.Application.AirPortAppService.Dtos;
using BookingEngine.Application.AirPortAppService.Validations;
using BookingEngine.Application.AmenitiesAppService;
using BookingEngine.Application.AmenitiesAppService.Dtos;
using BookingEngine.Application.AmenitiesAppService.Validations;
using BookingEngine.Application.AuditAppService;
using BookingEngine.Application.AuditAppService.Dtos;
using BookingEngine.Application.AuditAppService.Validations;
using BookingEngine.Application.ExchangeCurrencyAppService;
using BookingEngine.Application.ExchangeCurrencyAppService.Dtos;
using BookingEngine.Application.ExchangeCurrencyAppService.Validations;
using BookingEngine.Application.Filters;
using BookingEngine.Application.LocationAppService;
using BookingEngine.Application.LocationAppService.Dtos;
using BookingEngine.Application.LocationAppService.Validations;
using BookingEngine.Application.OTAUserAppService;
using BookingEngine.Application.OTAUserAppService.Dtos;
using BookingEngine.Application.OTAUserAppService.Validations;
using BookingEngine.Application.OTAUserService;
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
using BookingEngine.Application.WrappingAppService.WrappingPaymentAppService;
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
            services.AddTransient<AuditValidator>();

            services.AddTransient<IInquirePNRRequestAppService, InquirePNRRequestAppService>();
            services.AddTransient<AuditValidator>();


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


            services.AddScoped<IAmenitiesAppService, AmenitiesAppService>();
            services.AddTransient<AmenitiesValidator>();


            services.AddScoped<ISieveProcessor, BookingEngineFilters>();
            services.AddSingleton<ISieveConfiguration, BookingEngineFiltersConfiguration>();

            services.AddScoped<IPaymentAppService, PaymentAppService>();


            services.AddScoped<IExchangeCurrencyAppService, ExchangeCurrencyAppService>();
            services.AddTransient<ExchangeCurrencyValidator>();


            services.AddScoped<ILocationAppService, LocationAppService>();
            services.AddTransient<LocationValidator>();
            
            services.AddScoped<IWrappingPaymentAppService, WrappingPaymentAppService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AirPortMapperProfile());
                mc.AddProfile(new SearchRequestMapperProfile());
                mc.AddProfile(new OTAUserMapperProfile());
                mc.AddProfile(new ReservationInfoMapperProfile());
                mc.AddProfile(new POSMapperProfile());
                mc.AddProfile(new StripeResultMapperProfile());
                mc.AddProfile(new InquirePNRMapperProfile());
                mc.AddProfile(new ExchangeCurrencyInputMapperProfile());
                mc.AddProfile(new AmenitiesMapperProfile());
                mc.AddProfile(new LocationMapperProfile());


            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            //services.AddScoped<ISieveProcessor, SieveProcessor>();

        }
    }


}
