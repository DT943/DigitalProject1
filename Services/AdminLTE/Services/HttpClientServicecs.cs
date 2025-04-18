﻿using System.Net.Http.Headers;

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
                Timeout = TimeSpan.FromMinutes(0.05) // Increase timeout in case of delays
            };


            //var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri($"http://92.112.184.210:{port}");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ0YXJlazNzaGVpa2hhbGFyZCIsImp0aSI6IjMxNmIwNTJmLWVlNDUtNDMyOS1hYmMzLTIwNjY2YzY0N2MxOSIsImVtYWlsIjoidGFyZWszLmRvZUBleGFtcGxlLmNvbSIsInVzZXJDb2RlIjoiQ3VzdG9tZXItNWI5MTA1ODc3ZGRmNDY1YjljMjJiZjZjNmZmOGJjOWMiLCJyb2xlcyI6IkN1c3RvbWVyIiwiZXhwIjoxNzQxOTA0NTcyLCJpc3MiOiJTZWN1cmVBcGkiLCJhdWQiOiJTZWN1cmVBcGlVc2VyIn0.1MQc_UG9xIpi4QcE0jjb_p62ShIv3MqjREdhl3Wmpa8");
            return client;
        }

    }
}