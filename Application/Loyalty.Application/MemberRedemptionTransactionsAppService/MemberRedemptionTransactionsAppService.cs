using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Loyalty.Application.MemberPreferenceDetailsAppService.Dto;
using Loyalty.Application.MemberPreferenceDetailsAppService.Validations;
using Loyalty.Application.MemberPreferenceDetailsAppService;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Loyalty.Application.MemberRedemptionTransactions.Dto;
using Loyalty.Application.MemberRedemptionTransactions.Validations;
using FluentValidation;
using Loyalty.Domain.Models;

namespace Loyalty.Application.MemberRedemptionTransactions
{
    public class MemberRedemptionTransactionsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberRedemptionTransactions, MemberRedemptionTransactionsGetDto, MemberRedemptionTransactionsGetDto, MemberRedemptionTransactionsCreateDto, MemberRedemptionTransactionsUpdateDto, SieveModel>, IMemberRedemptionTransactionsAppService
    {
        public MemberRedemptionTransactionsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberRedemptionTransactionsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }


        public override async Task<MemberRedemptionTransactionsGetDto> Create(MemberRedemptionTransactionsCreateDto create)
        {
            var validationResult = await _validations.ValidateAsync(create, options => options.IncludeRuleSets("create", "default"));

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var entity = BeforCreate(create);

            var allTransactions = _serviceDbContext.MemberAccrualTransactions.Where(x => x.BonusValidationDate >= DateTime.Now && x.CIS == create.CIS).OrderByDescending(x => x.BonusValidationDate).ToList();

            entity.MemberTransactionRedemptionDetails = new List<MemberTransactionRedemptionDetails>();

            int usedMiles = create.UsedMiles;
            int redemptionValue = 0;

            foreach (var transaction in allTransactions)
            {
                var redemptionAggregation =  _serviceDbContext.MemberTransactionRedemptionDetails
                    .Where(x => x.TransactionId == transaction.Id)
                    .GroupBy(x => x.TransactionId)
                    .Select(group => new
                    {
                        TransactionId = group.Key,
                        TotalRedemptionValue = group.Sum(x => x.RedemptionValue)
                    })
                    .FirstOrDefault();


                int transactionAmount = (int)((transaction.Base ?? 0) + transaction.Bonus);

                var remainingAmount = transactionAmount - (redemptionAggregation == null? 0 : redemptionAggregation.TotalRedemptionValue);

                if (remainingAmount <= 0) continue;


                redemptionValue = usedMiles < remainingAmount ? usedMiles : remainingAmount;


                entity.MemberTransactionRedemptionDetails.Add(new MemberTransactionRedemptionDetails
                {
                    TransactionId = transaction.Id,
                    RedemptionValue = redemptionValue
                });



                usedMiles -= redemptionValue;
                if (usedMiles <= 0) break;

            }

            var result = await _serviceDbContext.Set<Domain.Models.MemberRedemptionTransactions>().AddAsync(entity);
            await _serviceDbContext.SaveChangesAsync();
            return await Get(result.Entity.Id);
        }
    }
}
