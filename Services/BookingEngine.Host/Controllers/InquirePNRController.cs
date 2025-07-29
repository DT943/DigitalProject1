using AutoMapper;
using BookingEngine.Application.AuditAppService;
using BookingEngine.Application.AuditAppService.Dtos;
using BookingEngine.Application.PaymantAppService.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService;
using BookingEngine.Application.WrappingAppService.WrappingBookingAppService.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using InquirePNRCreateDto = BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos.InquirePNRCreateDto;

namespace BookingEngine.Host.Controllers
{
    public class InquirePNRController :BaseController<IInquirePNRRequestAppService, Domain.Models.InquirePNR, InquirePNRAuditWithIPGetDto, InquirePNRAuditWithIPGetDto, InquirePNRAuditCreateDto, InquirePNRUpdateDto, SieveModel>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        private readonly IWrappingInquirePNRAppService _inquirePNRAppService;

        public InquirePNRController(IInquirePNRRequestAppService appService, IWrappingInquirePNRAppService inquirePNRAppService, IHttpContextAccessor httpContextAccessor, IMapper mapper) : base(appService, Servics.BookingEngine)
        {
            _inquirePNRAppService = inquirePNRAppService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;

        }


        [HttpPost("Create")]
        public async Task<IActionResult> CreateOnHoldBooking(InquirePNRCreateDto inquirePNRCreateDto)
        {
             
            var inquirePNR = await _inquirePNRAppService.InquirePNRAsync(inquirePNRCreateDto);

            var httpContext = _httpContextAccessor.HttpContext;

            // Get client IP address
            string clientIp = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(clientIp))
            {
                clientIp = httpContext.Connection.RemoteIpAddress?.ToString();
            }

            // Get user agent
            string userAgent = httpContext.Request.Headers["User-Agent"].FirstOrDefault();

            var inquirePNRAudit = new InquirePNRAuditCreateDto
            {
                LastName = inquirePNRCreateDto.LastName,
                PNR = inquirePNRCreateDto.PNR,
                IpAddress = clientIp ?? "",
                CreatedAt = DateTime.UtcNow,
                UserAgent = userAgent ?? "",
                InquirePNRRsponseDto = _mapper.Map<BookingEngine.Application.AuditAppService.Dtos.InquirePNRCreateDto>(inquirePNR)
            };
            var audit = await _appService.Create(inquirePNRAudit);

            // Check for error in the response
            if (inquirePNR?.Status?.ToLower() == "error")
            {
                var errorMessage = string.Join("; ", inquirePNR.Errors ?? new List<string> { "Unknown error occurred." });
                return BadRequest(new
                {
                    status = "error",
                    errors = inquirePNR.Errors,
                });
            }

            return Ok(inquirePNR);
        }

    }
}

