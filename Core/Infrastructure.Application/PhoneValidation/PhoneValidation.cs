using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Application.PhoneValidation
{
    public class PhoneValidation
    {

        public static async Task<bool> GetPhoneValidationAsync(string apiKey, string phone)
        {

            string url = $"https://phonevalidation.abstractapi.com/v1/?api_key={apiKey}&phone={phone}";
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Parse the JSON response to extract the validation score
                    JObject jsonResponse = JObject.Parse(responseBody);
                    bool valid = jsonResponse["valid"].Value<bool>();

                    return valid;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Phone validation error: {ex.Message}");
                return false;
            }


        }

    }
}


