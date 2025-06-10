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
                    .WithMessage("CIS Cann't Be Null").
                     Must((cis) => loyaltyRepository.MemberDemographicsAndProfiles.Any(x => x.UserCode == cis))
                    .WithMessage("The User Not Found");

                RuleFor(dto => (dto as MemberAccrualTransactionsCreateDto).Description)
                  .NotEmpty()
                  .WithMessage("The Description Cannot Be Null");

                RuleFor(dto => (dto as MemberAccrualTransactionsCreateDto).PartnerCode)
                  .NotEmpty()
                  .WithMessage("The Partner Code Cannot Be Null");
            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as MemberAccrualTransactionsUpdateDto).CIS)
                    .NotEmpty()
                    .WithMessage("The Type of the Component cannot be empty.").
                     Must((cis) => loyaltyRepository.MemberDemographicsAndProfiles.Any(x => x.UserCode == cis))
                    .WithMessage("The User Not Found");
            });

            RuleSet("FlightCreate", () =>
            {
                RuleFor(dto => (dto as MemberAccrualTransactionsFlightCreateDto).FlightClass)
                    .NotEmpty().WithMessage("FlightClass is required.");
                RuleFor(dto => (dto as MemberAccrualTransactionsFlightCreateDto).BookClass)
                    .NotEmpty().WithMessage("BookClass is required.");
                RuleFor(dto => (dto as MemberAccrualTransactionsFlightCreateDto).Origin)
                    .NotEmpty().WithMessage("Origin is required.");
                RuleFor(dto => (dto as MemberAccrualTransactionsFlightCreateDto).Destination)
                    .NotEmpty().WithMessage("Destination is required.");

                RuleFor(dto => (dto as MemberAccrualTransactionsFlightCreateDto))
                    .Must(dto =>
                    {
                        var res = !loyaltyRepository.MemberAccrualTransactions.Any(x =>
                            x.CIS == dto.CIS &&
                            x.TravelDate == dto.TravelDate && // Use .Date for equality
                            x.Origin == dto.Origin &&
                            x.Destination == dto.Destination
                        );
 
                        return res;
                    })
                    .WithMessage("Duplicate Transaction");

            });

            RuleSet("PaidCreate", () =>
            {
                RuleFor(dto => (dto as PaymentDetails).Amount)
                    .NotEmpty().WithMessage("Amount is required."); 
            });
        }
    }
}
