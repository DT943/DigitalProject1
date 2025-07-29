using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BookingEngine.Application.ExternalServicesAppService.TicketGallary
{
    public class CreateTicketPdfFileAppService : ICreateTicketPdfFileAppService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CreateTicketPdfFileAppService> _logger;

        public CreateTicketPdfFileAppService(IHttpClientFactory httpClientFactory,
                    ILogger<CreateTicketPdfFileAppService> logger)

        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;

        }

        public async Task<string> UploadFileToGalleryAsync(
            byte[] fileBytes,
            string title,
            string fileName,
            string caption,
            string description,
            string altText,
            int galleryId = 3)
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                // Step 1: Login
                _logger.LogInformation("Logging in to get JWT token...");

                var loginPayload = new
                {
                    email = "yasserkahla8@gmail.com",
                    password = "Hi@2025"
                };

                var loginContent = new StringContent(JsonSerializer.Serialize(loginPayload), Encoding.UTF8, "application/json");
                var loginResponse = await client.PostAsync("https://flycham.com/api/auth/authentication/login", loginContent);

                if (!loginResponse.IsSuccessStatusCode)
                {
                    var error = await loginResponse.Content.ReadAsStringAsync();
                    _logger.LogError("Login failed with status {StatusCode}. Response: {Error}", loginResponse.StatusCode, error);
                    throw new Exception($"Login failed: {loginResponse.StatusCode} - {error}");
                }

                var loginJson = JsonDocument.Parse(await loginResponse.Content.ReadAsStringAsync());
                var token = loginJson.RootElement.GetProperty("token").GetString();

                _logger.LogInformation("Login successful. Token acquired.");

                // Step 2: Set token
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Step 3: Prepare upload content
                _logger.LogInformation("Preparing file upload content...");

                using var content = new MultipartFormDataContent();

                var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/pdf");

                content.Add(fileContent, "File", fileName);
                content.Add(new StringContent(title ?? ""), "Title");
                content.Add(new StringContent(caption ?? ""), "caption");
                content.Add(new StringContent(description ?? ""), "description");
                content.Add(new StringContent(altText ?? ""), "alternativeText");
                content.Add(new StringContent(galleryId.ToString()), "galleryId");

                // Step 4: Upload
                _logger.LogInformation("Uploading file to gallery...");

                var response = await client.PostAsync("https://flycham.com/api/gallery/file", content);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Upload failed with status {StatusCode}. Response: {Error}", response.StatusCode, error);
                    throw new Exception($"Upload failed: {response.StatusCode} - {error}");
                }

                var responseString = await response.Content.ReadAsStringAsync();
                var json = JsonDocument.Parse(responseString);
                var fileNameFromResponse = json.RootElement.GetProperty("fileName").GetString();

                var finalUrl = $"https://flycham.com/api/gallery/{fileNameFromResponse}";

                _logger.LogInformation("Upload successful. File URL: {FileUrl}", finalUrl);

                return finalUrl;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while uploading the file to the gallery.");
                throw;
            }
        }
    }
}

