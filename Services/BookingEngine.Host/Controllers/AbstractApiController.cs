using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BookingEngine.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AbstractApiController : Controller
    {
        private readonly string _emailApiKey;
        private readonly string _phoneApiKey;

        public AbstractApiController(IConfiguration configuration)
        {
            _emailApiKey = configuration["EmailValidation:ApiKey"];
            _phoneApiKey = configuration["PhoneValidation:ApiKey"];
        }

        [HttpGet("ValidateEmail")]
        public async Task< ActionResult<bool> >ValidateEmail([FromQuery] string email)
        {
            string url = $"https://emailvalidation.abstractapi.com/v1/?api_key={_emailApiKey}&email={email}";

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
                    else
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
        [HttpGet("ValidatePhone")]

        public async Task<ActionResult<bool>> ValidatePhone([FromQuery] string phoneNumber)
        {
            string url = $"https://phonevalidation.abstractapi.com/v1/?api_key={_phoneApiKey}&phone={phoneNumber}";
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
