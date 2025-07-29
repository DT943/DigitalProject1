using BookingEngine.Application.MailModoAppService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingEngine.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailModoController : ControllerBase
    {
        private readonly IMailModoAppService _mailModoAppService;

        public MailModoController(IMailModoAppService mailModoAppService)
        {
            _mailModoAppService = mailModoAppService;
        }
        /*
        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] MailModoEmailDto dto)
        {
            var variables = new Dictionary<string, string>
            {
                ["Name"] = dto.Name,
                ["PNR"] = dto.PNR,
                ["Origin"] = dto.Origin,
                ["Destination"] = dto.Destination,
                ["Flight Number"] = dto.FlightNumber,
                ["Departure Date"] = dto.DepartureDate,
                ["Flight Class"] = dto.FlightClass,
                ["Arrival Date"] = dto.ArrivalDate,
                ["Departure Time"] = dto.DepartureTime,
                ["Arrival Time"] = dto.ArrivalTime,
                ["Total Fare"] = dto.TotalFare,
                ["Currency"] = dto.Currency,
                ["URL"] = dto.URL
            };

            await _mailModoAppService.SendMailmodoEmail(dto.ContactEmail, variables);
            return Ok(new { message = "Email sent successfully." });
        }
    }

    public class MailModoEmailDto
    {
        public string Name { get; set; }
        public string PNR { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string FlightNumber { get; set; }
        public string DepartureDate { get; set; }
        public string FlightClass { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string TotalFare { get; set; }
        public string Currency { get; set; }
        public string URL { get; set; }
        public string ContactEmail { get; set; }

    }
        */
    }

}
