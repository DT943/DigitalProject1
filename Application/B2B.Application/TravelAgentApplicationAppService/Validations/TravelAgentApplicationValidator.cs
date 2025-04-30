using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using CWCore.Application.POSAppService;
using FluentValidation;
using Infrastructure.Application.EmailValidation;
using Infrastructure.Application.Validations;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace B2B.Application.TravelAgentApplicationAppService.Validations
{
    public class TravelAgentApplicationValidator : AbstractValidator<IValidatableDto>
    {
        IPOSAppService _appService;

        public TravelAgentApplicationValidator(IPOSAppService appService, IConfiguration configuration)
        {
            _appService = appService;
            string _emailValidationApiKey = configuration["EmailValidation:ApiKey"];
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as TravelAgentApplicationCreateDto).TravelAgencyName)
                    .NotEmpty()
                    .WithMessage("The Travel Agency Name cannot be empty.")
                    .Must(name => name == null || name == name.ToLower())
                    .WithMessage("Travel Agency Name must be in lowercase.");

                RuleFor(dto => (dto as TravelAgentApplicationCreateDto).AccelAeroUserName)
                    .NotEmpty()
                    .WithMessage("The Accel Aero User Name cannot be empty.")
                    .Must(name => name == null || name == name.ToLower())
                    .WithMessage("The Accel Aero User Name must be in lowercase.");


                RuleFor(dto => (dto as TravelAgentApplicationCreateDto).PhoneNumber)
                    .Matches(@"^\+?[0-9\s\-]{7,15}$")
                    .WithMessage("The PhoneNumber format is invalid.");

                RuleFor(dto => (dto as TravelAgentApplicationCreateDto).Email)
                    .NotEmpty()
                    .WithMessage("The Email cannot be empty.")
                    .EmailAddress()
                    .WithMessage("The Email format is invalid.").EmailAddress()
                    .WithMessage("Invalid email format.")
                    .MustAsync(async (email, cancellation) =>
                    {
                        var score = await EmailValidation.GetEmailValidationScore(_emailValidationApiKey, email);
                        return score;
                    }).WithMessage("This email is not valid.");

                RuleFor(dto => (dto as TravelAgentApplicationCreateDto).POS)
                     .MustAsync(async (pos, cancellation) =>
                     { 
                           var result = await _appService.GetByPOSKey(pos);
                           return result != null;
                     })
                    .WithMessage("POS must be in lowercase if provided.")
                    .Must(name => name == null || name == name.ToLower())
                    .WithMessage("POS must be in lowercase.")
                    .NotEmpty()
                    .WithMessage("The POS Name cannot be empty.");

                RuleForEach(dto => (dto as TravelAgentApplicationCreateDto).Employees).ChildRules(employee =>
                {
                    employee.RuleFor(e => e.EmployeeEmail)
                        .NotEmpty().WithMessage("Employee email is required.")
                        .EmailAddress().WithMessage("Invalid email format.").MustAsync(async (email, cancellation) =>
                        {
                            var score = await EmailValidation.GetEmailValidationScore(_emailValidationApiKey, email);
                            return score;
                        }).WithMessage("This email is not valid.")

                        .MaximumLength(100);

                    employee.RuleFor(e => e.Role)
                        .NotEmpty().WithMessage("Role is required.")
                        .MaximumLength(100);

                    employee.RuleFor(e => e.PhoneNumber)
                        .NotEmpty().WithMessage("Phone number is required.")
                        .Matches(@"^\+?[0-9\s\-]{7,15}$").WithMessage("Phone number format is invalid.")
                        .MaximumLength(100);
                });

            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as TravelAgentApplicationUpdateDto).TravelAgencyName)
                    .NotEmpty()
                    .WithMessage("The Travel Agency Name cannot be empty.")
                    .Must(name => name == null || name == name.ToLower())
                    .WithMessage("Travel Agency Name must be in lowercase.");

                RuleFor(dto => (dto as TravelAgentApplicationUpdateDto).AccelAeroUserName)
                    .NotEmpty()
                    .WithMessage("The Accel Aero User Name cannot be empty.")
                    .Must(name => name == null || name == name.ToLower())
                    .WithMessage("The Accel Aero User Name must be in lowercase.");


                RuleFor(dto => (dto as TravelAgentApplicationUpdateDto).PhoneNumber)
                    .Matches(@"^\+?[0-9\s\-]{7,15}$")
                    .WithMessage("The PhoneNumber format is invalid.");

                RuleFor(dto => (dto as TravelAgentApplicationUpdateDto).Email)
                    .NotEmpty()
                    .WithMessage("The Email cannot be empty.")
                    .EmailAddress()
                    .WithMessage("The Email format is invalid.")
                    .MustAsync(async (email, cancellation) =>
                        {
                            var score = await EmailValidation.GetEmailValidationScore(_emailValidationApiKey, email);
                            return score;
                        }).WithMessage("This email is not valid.");

                RuleFor(dto => (dto as TravelAgentApplicationUpdateDto).POS)
                     .MustAsync(async (pos, cancellation) =>
                     {
                         var result = await _appService.GetByPOSKey(pos);
                         return result != null;
                     })
                    .WithMessage("POS must be in lowercase if provided.")
                    .Must(name => name == null || name == name.ToLower())
                    .WithMessage("POS must be in lowercase.")
                    .NotEmpty()
                    .WithMessage("The POS Name cannot be empty.");

                RuleForEach(dto => (dto as TravelAgentApplicationUpdateDto).Employees).ChildRules(employee =>
                {
                    employee.RuleFor(e => e.EmployeeEmail)
                        .NotEmpty().WithMessage("Employee email is required.")
                        .EmailAddress().WithMessage("Invalid email format.")
                        .MustAsync(async (email, cancellation) =>
                        {
                            var score = await EmailValidation.GetEmailValidationScore(_emailValidationApiKey, email);
                            return score;
                        })
                         .WithMessage("This email is not valid.")
                        .MaximumLength(100);

                    employee.RuleFor(e => e.Role)
                        .NotEmpty().WithMessage("Role is required.")
                        .MaximumLength(100);

                    employee.RuleFor(e => e.PhoneNumber)
                        .NotEmpty().WithMessage("Phone number is required.")
                        .Matches(@"^\+?[0-9\s\-]{7,15}$").WithMessage("Phone number format is invalid.")
                        .MaximumLength(100);
                });
            });
        }

    }
}
