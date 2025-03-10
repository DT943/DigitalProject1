using System.Net.Http.Headers;

namespace AdminLTE.Services
{
    public class HttpClientService
    {
        //private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public HttpClient GetHttpClient(string port)
        {
            var handler = new HttpClientHandler
            {
                // Bypass SSL certificate validation (ONLY USE FOR TESTING!)
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri($"https://92.112.184.210:{port}"),
                Timeout = TimeSpan.FromMinutes(2) // Increase timeout in case of delays
            };


            //var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri($"http://92.112.184.210:{port}");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ0YXJlazNzaGVpa2hhbGFyZCIsImp0aSI6IjdmYWY5OGQ3LTljMzEtNDZmMS04YjljLWEzMmQzOTMyYjA3NiIsImVtYWlsIjoidGFyZWszLmRvZUBleGFtcGxlLmNvbSIsInVzZXJDb2RlIjoiQ3VzdG9tZXItNWI5MTA1ODc3ZGRmNDY1YjljMjJiZjZjNmZmOGJjOWMiLCJyb2xlcyI6IkN1c3RvbWVyIiwiZXhwIjoxNzQxNjc3Nzg4LCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VyIn0.k4S1-cMQSdh6cErR2aF5Lald_5OTSV-jk8J2f_nR-sE");
            return client;
        }

    }
}