using AutoMapper;
using Sieve.Services;
using TicketIssue.Application.TicketIssueAppService;
using TicketIssue.Application.TicketIssueAppService.Dtos;
using TicketIssue.Application.TicketIssueAppService.Validations;

namespace TicketIssue.Host.Helper
{
    public static class ServiceExtensions
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<ITicketIssueAppService, TicketIssueAppService>();

            services.AddTransient<TicketIssueValidator>();
            services.AddScoped<ISieveProcessor, SieveProcessor>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TicketIssueMapperProfile());
            });


            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
