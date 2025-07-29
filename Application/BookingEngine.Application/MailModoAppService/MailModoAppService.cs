using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BookingEngine.Application.MailModoAppService.Dtos;
using BookingEngine.Application.MailModoResultAppService;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BookingEngine.Application.MailModoAppService
{
    public class MailModoAppService : IMailModoAppService
    {
        private readonly MailmodoSettingsDto _settings;
        private readonly ILogger<MailModoAppService> _logger;
        private readonly IMailModoResultAppService _mailModoResultAppService;

        public MailModoAppService(
            IOptions<MailmodoSettingsDto> options,
            ILogger<MailModoAppService> logger,
            IMailModoResultAppService mailModoResultAppService)
        {
            _settings = options.Value;
            _logger = logger;
            _mailModoResultAppService = mailModoResultAppService;
        }

        public async Task SendMailmodoEmail(
            string recipientEmail,
            Dictionary<string, string> dataVariables,
            string CampainName,
            Dictionary<string, string>? campaignDataVariables = null,
            string? subject = null,
            string? replyTo = null,
            string? fromName = null,
            string? addToList = null
            )
        {


            using var client = new HttpClient();

            client.DefaultRequestHeaders.Add("mmApiKey", _settings.ApiKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var CampainId = "";

            if (CampainName == "CampaignRoundTripBusinessBooking")
            {
                CampainId = _settings.CampaignRoundTripBusinessBooking;
            }
            else if (CampainName == "CampaignOneWayBusinessBooking")
            {
                CampainId = _settings.CampaignOneWayBusinessBooking;

            }
            else if (CampainName == "CampaignRoundTripEconomyBooking")
            {

                CampainId = _settings.CampaignnRoundTripEconomyBooking;

            }
            else if (CampainName == "CampaignOneWayEconomyBooking")
            {
                CampainId = _settings.CampaignOneWayEconomyBooking;

            }
            var url = $"https://api.mailmodo.com/api/v1/triggerCampaign/{CampainId}";

            var payload = new Dictionary<string, object>
            {
                { "email", recipientEmail },
                { "data", dataVariables }
            };

            if (!string.IsNullOrWhiteSpace(subject)) payload["subject"] = subject;
            if (!string.IsNullOrWhiteSpace(replyTo)) payload["replyTo"] = replyTo;
            if (!string.IsNullOrWhiteSpace(fromName)) payload["fromName"] = fromName;
            if (campaignDataVariables != null && campaignDataVariables.Any()) payload["campaign_data"] = campaignDataVariables;
            if (!string.IsNullOrWhiteSpace(addToList)) payload["addToList"] = addToList;

            var json = JsonSerializer.Serialize(payload);
            _logger.LogInformation("Sending Mailmodo campaign to {Email} with payload: {Payload}", recipientEmail, json);

            var status = "Success";
            try
            {
                var response = await client.PostAsync(url,
                    new StringContent(json, Encoding.UTF8, "application/json"));

                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Successfully sent Mailmodo campaign email to {Email}. Response: {Response}", recipientEmail, responseContent);
                }
                else
                {
                    status = "Failed";
                    _logger.LogError("Failed to send Mailmodo campaign email to {Email}. StatusCode: {StatusCode}, Response: {Response}",
                        recipientEmail, response.StatusCode, responseContent);
                }

                var result = new MailModoCreateDto()
                {
                    CreatedAt = DateTime.Now,
                    Status = status,
                    Email = recipientEmail,
                    PNR = dataVariables.TryGetValue("PNR", out var pnr) ? pnr : "" ,
                    URL = dataVariables.TryGetValue("URL", out var urlticket) ? urlticket : ""
                };

                await _mailModoResultAppService.Create(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while sending Mailmodo campaign email to {Email}", recipientEmail);
            }
        }
    }
}
