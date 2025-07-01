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

/*
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Notification.Application
{
    public class EmailAppService : IEmailAppService
    {
        private readonly IConfiguration _configuration;

        public EmailAppService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string password, string userName)
        {
            var smtpHost = _configuration["Smtp:Host"];       // e.g., "smtp.gmail.com"
            var smtpPort = int.Parse(_configuration["Smtp:Port"]); // e.g., 587
            var smtpUser = _configuration["Smtp:Username"];   // your email address
            var smtpPass = _configuration["Smtp:Password"];   // your email password or app password
            var fromEmail = _configuration["Smtp:FromEmail"]; // usually same as smtpUser

            var body = $"Dear {userName},\n\nYour password is: {password}\n\nRegards,\nYour Company";

            using var message = new MailMessage(fromEmail, toEmail, subject, body);
            using var smtpClient = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUser, smtpPass),
                EnableSsl = true
            };

            await smtpClient.SendMailAsync(message);
        }
    }
}


"Smtp": {
    "Host": "smtp.gmail.com",
  "Port": "587",
  "Username": "your-email@gmail.com",
  "Password": "your-email-password-or-app-password",
  "FromEmail": "your-email@gmail.com"
}
*/