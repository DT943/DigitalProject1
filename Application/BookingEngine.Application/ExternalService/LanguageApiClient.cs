using System.Net.Http.Json;

namespace BookingEngine.Application.ExternalService
{
    public class LanguageApiClient : ILanguageApiClient
    {
        private readonly HttpClient _httpClient;

        public LanguageApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> GetActiveLanguageCodesAsync()
        {
            var response = await _httpClient.GetAsync("/Language/ActiveLanguages");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<string>>();
        }
    }

}
