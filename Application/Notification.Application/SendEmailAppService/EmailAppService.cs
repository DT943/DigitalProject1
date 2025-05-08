
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;

namespace Notification.Application
{
    public class EmailAppService : IEmailAppService
    {

        private readonly HttpClient _httpClient;

        public EmailAppService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendEmailAsync(string email, string subject, string password, string userName)
        {
            var payload = new
            {
                email = email,
                subject = subject,
                userName = userName,
                password = password,
            };
            //https://hooks.zapier.com/hooks/catch/17823706/2ef80xk/
            var jsonPayload = JsonSerializer.Serialize(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://hooks.zapier.com/hooks/catch/17823706/2ef80xk/", content);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch(Exception e)
            {

            }

        }

    }
}
