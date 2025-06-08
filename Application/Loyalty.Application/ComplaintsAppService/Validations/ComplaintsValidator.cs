using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using Loyalty.Application.ComplaintsAppService.Dtos;
using Loyalty.Data.DbContext;

namespace Loyalty.Application.ComplaintsAppService.Validations
{
    public class ComplaintsValidator : AbstractValidator<IValidatableDto>
    {
        public ComplaintsValidator(LoyaltyDbContext loyaltyRepository)
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as ComplaintsCreateDto).CIS)
                    .NotEmpty()
                    .WithMessage("CIS Cannot be empty.").
                     Must((cis) => loyaltyRepository.MemberDemographicsAndProfiles.Any(x => x.UserCode == cis))
                    .WithMessage("The User Not Found");

                RuleFor(dto => (dto as ComplaintsCreateDto).Description)
                    .NotEmpty()
                    .WithMessage("The Description cannot be empty.");
            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as ComplaintsCreateDto).CIS)
                    .NotEmpty()
                    .WithMessage("CIS Cannot be empty.").
                     Must((cis) => loyaltyRepository.MemberDemographicsAndProfiles.Any(x => x.UserCode == cis))
                    .WithMessage("The User Not Found");
            });
        }
    }
}