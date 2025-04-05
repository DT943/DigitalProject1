using AutoMapper;
using Event.Application.EventAppService;
using Event.Application.EventAppService.Dtos;
using Event.Application.EventAppService.Validations;
using Event.Application.TicketAppService;
using Event.Application.TicketAppService.Dtos;
using Event.Application.TicketAppService.Validations;
using Sieve.Services;

namespace Event.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IEventAppService, EventAppService>(); 
            services.AddTransient<EventValidator>();

            services.AddTransient<ITicketAppService, TicketAppService>();
            services.AddTransient<TicketValidator>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EventMapperProfile());
                mc.AddProfile(new TicketMapperProfile());

            });
            services.AddScoped<ISieveProcessor, SieveProcessor>();

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
