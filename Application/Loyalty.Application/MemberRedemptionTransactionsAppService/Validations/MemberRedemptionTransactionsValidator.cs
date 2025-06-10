using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Loyalty.Application.MemberRedemptionTransactions.Dto;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Loyalty.Application.MemberRedemptionTransactions.Validations
{
    public class MemberRedemptionTransactionsValidator : AbstractValidator<IValidatableDto>
    {
        public MemberRedemptionTransactionsValidator(LoyaltyDbContext loyaltyRepository)
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as MemberRedemptionTransactionsCreateDto).CIS)
                    .NotEmpty()
                    .WithMessage("The Type of the Component cannot be empty.").
                     Must((cis) => loyaltyRepository.MemberDemographicsAndProfiles.Any(x => x.UserCode == cis))
                    .WithMessage("The User Not Found");

                RuleFor(dto => (dto as MemberRedemptionTransactionsCreateDto))
                   .Must((dto) =>
                   {
                        var allTransactions = loyaltyRepository.MemberAccrualTransactions
                            .Where(x => x.BonusValidationDate >= DateTime.Now && x.CIS == dto.CIS)
                            .ToList();

                        var transactionIds = allTransactions.Select(x => x.Id).ToList();
                        var totalAccrual = allTransactions.Sum(x => (x.Base ?? 0) + (x.Bonus ?? 0) +(x.Miles ?? 0));
                        var totalRedemption = loyaltyRepository.MemberTransactionRedemptionDetails
                            .Where(x => transactionIds.Contains(x.TransactionId))
                            .Sum(x => (int?)x.RedemptionValue) ?? 0;

                        return totalAccrual - totalRedemption >= dto.UsedMiles;
                   })
                   .WithMessage("The sum of all transaction Base and Bonus must be greater than the total redemption value for all related transactions.");

            });

            RuleSet("FlightCreate", () =>
            {
                RuleFor(dto => (dto as MemberRedemptionTransactionsCreateDto).FlightClass)
                    .NotEmpty().WithMessage("FlightClass is required.");
                RuleFor(dto => (dto as MemberRedemptionTransactionsCreateDto).Origin)
                    .NotEmpty().WithMessage("Origin is required.");
                RuleFor(dto => (dto as MemberRedemptionTransactionsCreateDto).Destination)
                    .NotEmpty().WithMessage("Destination is required.");
            });

            RuleSet("update", () =>
            {
            });
        }
    }
}