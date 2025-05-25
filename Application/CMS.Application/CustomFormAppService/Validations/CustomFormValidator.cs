using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.CustomFormAppService.Dto;
using CMS.Data.DbContext;
using FluentValidation;
using Infrastructure.Application.EmailValidation;
using Infrastructure.Application.Validations;
using Microsoft.Extensions.Configuration;

namespace CMS.Application.CustomFormAppService.Validations
{
    public class CustomFormValidator : AbstractValidator<IValidatableDto>
    {
        public string[] allowedServices = new string[]
        {
            "automotive",
            "steels_and_metals",
            "aviation",
            "vehicle_inspection",
            "real_estate",
            "alternative_energy",
            "food_manufacturing"
        };

        public CustomFormValidator(CMSDbContext cmsDbContext, IConfiguration configuration)
        {
            string _emailValidationApiKey = configuration["EmailValidation:ApiKey"];
            RuleSet("create", () =>
            {

                RuleFor(dto => (dto as CustomFormCreateDto).Email)
                    .NotEmpty()
                    .WithMessage("The Email of the Custom Form cannot be empty.")
                    .EmailAddress()
                    .WithMessage("The Email format is invalid.")
                    .MustAsync(async (email, cancellation) =>
                    {
                        var score = await EmailValidation.GetEmailValidationScore(_emailValidationApiKey, email);
                        return score;
                    })
                    .WithMessage("This email is not valid.");


                RuleFor(dto => (dto as CustomFormCreateDto).Services)
                    .NotEmpty()
                    .WithMessage("The Services of the Custom Form cannot be empty.")
                    .Must(raw =>
                    {
                        var services = raw.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                          .Select(s => s.Trim())
                                          .ToArray();
                        return services.All(s => allowedServices.Contains(s));
                    });

                RuleFor(dto => (dto as CustomFormCreateDto).PhoneNumber)
                    .NotEmpty()
                    .WithMessage("The Phone Number of the Custom Form cannot be empty.")
                    .Matches(@"^\+?[1-9]\d{1,14}$")
                    .WithMessage("The Phone Number format is invalid."); ;

                RuleFor(dto => (dto as CustomFormCreateDto).Description)
                    .NotEmpty()
                    .WithMessage("The Description of the Custom Form cannot be empty.");

            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as CustomFormCreateDto).Email)
                    .NotEmpty()
                    .WithMessage("The Email of the Custom Form cannot be empty.")
                    .EmailAddress()
                    .WithMessage("The Email format is invalid.")
                    .MustAsync(async (email, cancellation) =>
                    {
                        var score = await EmailValidation.GetEmailValidationScore(_emailValidationApiKey, email);
                        return score;
                    });

                RuleFor(dto => (dto as CustomFormCreateDto).Services)
                    .NotEmpty()
                    .WithMessage("The Services of the Custom Form cannot be empty.");

                RuleFor(dto => (dto as CustomFormCreateDto).PhoneNumber)
                    .NotEmpty()
                    .WithMessage("The Phone Number of the Custom Form cannot be empty.")
                    .Matches(@"^\+?[1-9]\d{1,14}$")
                    .WithMessage("The Phone Number format is invalid."); ;

                RuleFor(dto => (dto as CustomFormCreateDto).Description)
                    .NotEmpty()
                    .WithMessage("The Description of the Custom Form cannot be empty.");


            });
        }
    }
}
