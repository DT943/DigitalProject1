using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Application.OCRExternalAppService.Dtos;
using Newtonsoft.Json;

namespace Gallery.Application.OCRExternalAppService
{
    public class OCRExternalAppService : IOCRExternalAppService
    {

        private readonly HttpClient _httpClient;
        private const string OcrApiKey = "K89108572988957"; // 🔐 Replace with your actual API key
        private const string OcrEndpoint = "https://api.ocr.space/parse/image";

        public OCRExternalAppService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ExtractTextFromUrlAsync(string imageUrl)
        {
            imageUrl = "https://flycham.com/api/gallery/" + imageUrl;

            var extension = Path.GetExtension(imageUrl)?.TrimStart('.').ToLower();
            if (string.IsNullOrWhiteSpace(extension))
                extension = "jpg"; // Default fallback

            var request = new Dictionary<string, string>
            {
                { "apikey", OcrApiKey },
                { "language", "eng" },
                { "url", imageUrl },
                { "filetype", extension }

            };

            var content = new FormUrlEncodedContent(request);
            var response = await _httpClient.PostAsync(OcrEndpoint, content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            OcrResult result;
            try
            {
                result = JsonConvert.DeserializeObject<OcrResult>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse OCR.Space response: " + json, ex);
            }

            if (result.IsErroredOnProcessing)
            {
                var errorMsg = string.Join(" | ", result.ErrorMessage ?? new List<string> { "Unknown OCR error." });
                throw new Exception("OCR.Space returned an error: " + errorMsg);
            }

            return result.ParsedResults?.FirstOrDefault()?.ParsedText ?? string.Empty;
        }
    }
}
