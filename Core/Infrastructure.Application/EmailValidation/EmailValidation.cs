using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Application.EmailValidation
{
    public class EmailValidation
    {
        public static async Task<bool> GetEmailValidationScore(string apiKey, string email)
        {
            string url = $"https://emailvalidation.abstractapi.com/v1/?api_key={apiKey}&email={email}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // Throws exception if the HTTP response status is an error

                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Parse the JSON response to extract the validation score
                    JObject jsonResponse = JObject.Parse(responseBody);

                    //double validationScore = jsonResponse["quality_score"].Value<double>(); // Assuming 'quality_score' contains the validation score
                    string deliverability = jsonResponse["deliverability"].Value<string>();

                    //bool isvalid = jsonResponse["is_valid_format"].Value<bool>();
                    if (deliverability.Equals("DELIVERABLE")) 
                        return true;
                    return false;

                    // if (validationScore >= 0.9 && deliverability.Equals("UNKNOWN")) return true;
                    // deliverability
                    //return false;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                    return false; // Return -1 to indicate an error
                }
            }
        }


    }
}
