using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.EmailValidation;
using Infrastructure.Application.Validations;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Loyalty.Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Loyalty.Application.MemberDemographicsAndProfileAppService.Validations
{
    public class MemberDemographicsAndProfileValidator : AbstractValidator<IValidatableDto>
    {
        public MemberDemographicsAndProfileValidator(LoyaltyDbContext loyaltyRepository, IConfiguration configuration)
        {
            string _emailValidationApiKey = configuration["EmailValidation:ApiKey"];
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).Title)
               .MaximumLength(500);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).Initials)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).Email)
                 .NotEmpty()
                    .WithMessage("The Email of the Custom Form cannot be empty.")
                    .EmailAddress()
                    .WithMessage("The Email format is invalid.")
                     .MustAsync(async (email, cancellation) => await loyaltyRepository.MemberDemographicsAndProfiles.AnyAsync(x => x.Email.Equals(email)
                     ))
                    .WithMessage("This email is already excists.")
                    .MustAsync(async (email, cancellation) =>
                    {
                        var score = await EmailValidation.GetEmailValidationScore(_emailValidationApiKey, email);
                        return score;
                    })
                    .WithMessage("This email is not valid.");

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).FirstName)
                    .NotEmpty().WithMessage("First name is required.")
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).LastName)
                    .NotEmpty()
                    .WithMessage("Last name is required.")
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).NameOnCard)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).Gender)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).Language)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).BirthDate)
                    .LessThan(DateTime.Now).WithMessage("Birth date must be in the past.");

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).MaritalStatus)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).BussName)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).PassportNumber)
                    .MaximumLength(50);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).PassportExpiryDate)
                    .GreaterThan(DateTime.Today)
                    .WithMessage("Passport expiry date must be in the future.");


                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).IDNumber)
                    .MaximumLength(50);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).Nationality)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).Designation)
                    .MaximumLength(255);

                RuleFor(dto => (dto as MemberDemographicsAndProfileCreateDto).NumberOfChildren)
                    .GreaterThanOrEqualTo(0).WithMessage("Number of children cannot be negative.");
            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).Title)
                    .MaximumLength(500);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).Initials)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).Email)
                 .NotEmpty()
                    .WithMessage("The Email of the Custom Form cannot be empty.")
                    .EmailAddress()
                    .WithMessage("The Email format is invalid.")
                     .MustAsync(async (email, cancellation) => await loyaltyRepository.MemberDemographicsAndProfiles.AnyAsync(x => x.Email.Equals(email)
                     ))
                    .WithMessage("This email is already excists.")
                    .MustAsync(async (email, cancellation) =>
                    {
                        var score = await EmailValidation.GetEmailValidationScore(_emailValidationApiKey, email);
                        return score;
                    })
                    .WithMessage("This email is not valid.");

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).FirstName)
                    .NotEmpty().WithMessage("First name is required.")
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).LastName)
                    .NotEmpty()
                    .WithMessage("Last name is required.")
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).NameOnCard)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).Gender)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).Language)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).BirthDate)
                    .LessThan(DateTime.Now).WithMessage("Birth date must be in the past.");

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).MaritalStatus)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).BussName)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).PassportNumber)
                    .MaximumLength(50);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).PassportExpiryDate)
                    .GreaterThan(DateTime.Today)
                    .WithMessage("Passport expiry date must be in the future.");


                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).IDNumber)
                    .MaximumLength(50);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).Nationality)
                    .MaximumLength(100);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).Designation)
                    .MaximumLength(255);

                RuleFor(dto => (dto as MemberDemographicsAndProfileUpdateDto).NumberOfChildren)
                    .GreaterThanOrEqualTo(0).WithMessage("Number of children cannot be negative.");
            });
        }
    }
}
