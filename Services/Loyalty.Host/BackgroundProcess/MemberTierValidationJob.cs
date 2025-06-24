using Cronos;
using Loyalty.Application.MemberDemographicsAndProfileAppService;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Loyalty.Host.BackgroundProcess
{
    public class MemberTierValidationJob : BackgroundService
    {
        private readonly CronExpression _cronExpression;
        private readonly TimeZoneInfo _timeZoneInfo;
        private readonly ILogger<MemberTierValidationJob> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        public MemberTierValidationJob(ILogger<MemberTierValidationJob > logger, IServiceScopeFactory scopeFactory)
        {
            // Run once daily at 2:00 AM
            _logger = logger;
            _cronExpression = CronExpression.Parse("0 0 * * *");
            _timeZoneInfo = TimeZoneInfo.Local;
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var next = _cronExpression.GetNextOccurrence(DateTimeOffset.Now, _timeZoneInfo);
                if (next.HasValue)
                {
                    var delay = next.Value - DateTimeOffset.Now;
                    if (delay.TotalMilliseconds > 0)
                        await Task.Delay(delay, stoppingToken);

                    await DoDailyWorkAsync(stoppingToken);
                }
            }
        }


        private async Task DoDailyWorkAsync(CancellationToken token)
        {
            try
            {
                _logger.LogInformation("✅ Task started at {Time}", DateTime.Now); 
                using (var scope = _scopeFactory.CreateScope())
                {
                    var appService = scope.ServiceProvider.GetRequiredService<IMemberDemographicsAndProfileAppService>();
                    await appService.UpgradeAllUserTier();
                } 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error occurred during tier validation job");
            }
        }
    }
}
