using Authentication.Application;
using B2B.Application.TravelAgentApplicationAppService;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService.Validations;
using B2B.Application.TravelAgentEmployeeAppService;
using B2B.Application.TravelAgentOffice;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using B2B.Application.ReservationAppService;
using B2B.Application.ReservationAppService.Dto;
using B2B.Application.ReservationAppService.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ClosedXML.Excel;

namespace B2B.Host.Controllers
{
    [Authorize]
    public class ReservationController : BaseController<IReservationAppService, Domain.Models.Reservation, ReservationGetDto, ReservationGetDto, ReservationCreateDto, ReservationUpdateDto, SieveModel>
    {


        public ReservationController(IReservationAppService appService) : base(appService, Servics.B2B)
        {
       

        }


        [HttpGet("download-excel")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DownloadReservationsExcel([FromQuery] SieveModel sieve)
        {
            var reservations = await _appService.GetAll(sieve);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Reservations");

                // Add headers (customize as needed)
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "PNR";
                worksheet.Cell(1, 3).Value = "Number of Adults";
                worksheet.Cell(1, 4).Value = "Number of Childs";
                worksheet.Cell(1, 5).Value = "Number of Infants";
                worksheet.Cell(1, 6).Value = "POS";
                worksheet.Cell(1, 7).Value = "Flight Class";
                worksheet.Cell(1, 8).Value = "Origin Code";
                worksheet.Cell(1, 9).Value = "Origin Name";
                worksheet.Cell(1, 10).Value = "Destination Code";
                worksheet.Cell(1, 11).Value = "Destination Name";
                worksheet.Cell(1, 12).Value = "Departure Date";
                worksheet.Cell(1, 13).Value = "Departure Time";
                worksheet.Cell(1, 14).Value = "Arrival Date";
                worksheet.Cell(1, 15).Value = "Arrival Time";
                worksheet.Cell(1, 16).Value = "Total Fare";

 

                // Add more headers for related data if needed

                // Add data
                var row = 2;

               
                foreach (var reservation in reservations.Items)
                {
                    worksheet.Cell(row, 1).Value = reservation.Id;
                    worksheet.Cell(row, 2).Value = reservation.PNR;
                    worksheet.Cell(row, 3).Value = reservation.NumAdt;
                    worksheet.Cell(row, 4).Value = reservation.NumChd;
                    worksheet.Cell(row, 5).Value = reservation.NumInf;
                    worksheet.Cell(row, 6).Value = reservation.POS;
                    worksheet.Cell(row, 7).Value = reservation.FlightClass;
                    worksheet.Cell(row, 8).Value = reservation.OriginCode;
                    worksheet.Cell(row, 9).Value = reservation.OriginName;
                    worksheet.Cell(row, 10).Value = reservation.DestinationCode;
                    worksheet.Cell(row, 11).Value = reservation.DestinationName;
                    worksheet.Cell(row, 12).Value = reservation.DepartureDate.ToString();
                    worksheet.Cell(row, 13).Value = reservation.DepartureTime.ToString();
                    worksheet.Cell(row, 14).Value = reservation.ArrivalDate.ToString();
                    worksheet.Cell(row, 15).Value = reservation.ArrivalTime.ToString();
                    worksheet.Cell(row, 16).Value = reservation.TotalFare;
                    // Add more fields for related data if needed
                    row++;
                }

                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Reservations.xlsx");
                }
            }
        }

        public override async Task<ActionResult<ReservationGetDto>> Create(ReservationCreateDto dto)
        {
            var entity = await _appService.Create(dto);
            return Ok(entity);
        }
        public override async Task<ActionResult<ReservationGetDto>> GetAll([FromQuery] SieveModel sieve)
        {
            var user = HttpContext.User; 
            var entity = await _appService.GetAll(sieve);
            return Ok(entity);
        }
    }
}
