using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Loyalty.Application.MemberAccrualTransactions;
using Loyalty.Data.DbContext;
using Sieve.Models;
using Loyalty.Application.ComplaintsAppService.Dtos;
using AutoMapper;
using Loyalty.Application.MemberAddressDetailsAppService.Validations;
using Microsoft.AspNetCore.Http;
using Sieve.Services;
using Loyalty.Application.ComplaintsAppService.Validations;

namespace Loyalty.Application.ComplaintsAppService
{
    public class ComplaintsAppService: BaseAppService<LoyaltyDbContext, Domain.Models.Complaints, ComplaintsGetDto, ComplaintsGetDto, ComplaintsCreateDto, ComplaintsUpdateDto, SieveModel>, IComplaintsAppService
    {
        public ComplaintsAppService(IServiceProvider serviceProvider, LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, ComplaintsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {


        }

    }
}
