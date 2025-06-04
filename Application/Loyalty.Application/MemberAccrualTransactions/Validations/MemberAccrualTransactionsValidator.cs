using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Loyalty.Data.DbContext;

namespace Loyalty.Application.MemberAccrualTransactions.Validations
{
    public class MemberAccrualTransactionsValidator : AbstractValidator<IValidatableDto>
    {
        public MemberAccrualTransactionsValidator(LoyaltyDbContext loyaltyRepository)
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as MemberAccrualTransactionsCreateDto).CIS)
                    .NotEmpty()
                    .WithMessage("The Type of the Component cannot be empty.").
                     Must((cis) => loyaltyRepository.MemberDemographicsAndProfiles.Any(x => x.UserCode == cis))
                    .WithMessage("The User Not Found");
            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as MemberAccrualTransactionsUpdateDto).CIS)
                    .NotEmpty()
                    .WithMessage("The Type of the Component cannot be empty.").
                     Must((cis) => loyaltyRepository.MemberDemographicsAndProfiles.Any(x => x.UserCode == cis))
                    .WithMessage("The User Not Found");
            });
        }
    }
}
