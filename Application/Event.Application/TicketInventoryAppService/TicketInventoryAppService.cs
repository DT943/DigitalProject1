using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Event.Application.TicketAppService.Dtos;
using Event.Application.TicketAppService.Validations;
using Event.Application.TicketAppService;
using Event.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Event.Application.TicketInventoryAppService.Dtos;
using Event.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Event.Application.TicketInventoryAppService.Validations;

namespace Event.Application.TicketInventoryAppService
{
    public class TicketInventoryAppService : BaseAppService<EventDbContext, Domain.Models.TicketInventory, TicketInventoryGetAllDto, TicketInventoryGetDto, TicketInventoryCreateDto, TicketInventoryUpdateDto, SieveModel>, ITicketInventoryAppService
    {
        public TicketInventoryAppService(EventDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, TicketInventoryValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {

        }

        public async Task<List<TicketInventoryGetDto>> BuyTickets(TicketInventoryBuyDto TIB)
        {
            var soldTickets = new List<TicketInventoryGetDto>();
            for (int i=0;i<TIB.Quantity; i++)
            {
                string prefix = "TCK";
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff"); // includes milliseconds
                string randomPart = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper(); // 6 random characters
                string ticketNumber = $"{prefix}-{timestamp}-{randomPart}";

                soldTickets.Add(await base.Create(new TicketInventoryCreateDto
                {
                    TicketNumber = ticketNumber,
                    UserName = TIB.UserName,
                    Status = "sold",
                    PaymentTransaction = TIB.PaymentTransaction,
                    TicketIssueDate = DateTime.Now,
                    TicketId = TIB.TicketId
                }));
            }
            return soldTickets;
        }
    }
}

