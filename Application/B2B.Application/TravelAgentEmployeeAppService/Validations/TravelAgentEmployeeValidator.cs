using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Data.DbContext;
using CWCore.Application.POSAppService;
using FluentValidation;
using Infrastructure.Application.EmailValidation;
using Infrastructure.Application.Validations;
using Microsoft.Extensions.Configuration;

namespace B2B.Application.TravelAgentEmployeeAppService.Validations
{
    public class TravelAgentEmployeeValidator : AbstractValidator<IValidatableDto>
    {
        IPOSAppService _appService;

        public TravelAgentEmployeeValidator(B2BDbContext b2bDbContext, IConfiguration configuration, IPOSAppService appService, IAuthenticationAppService authenticationAppService)
        {
            string _emailValidationApiKey = configuration["EmailValidation:ApiKey"];
            appService = _appService;
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as TravelAgentEmployeeCreateDto).EmployeeEmail)
                    .NotEmpty()
                    .WithMessage("The Email of the Custom Form cannot be empty.")
                    .EmailAddress()
                    .WithMessage("The Email format is invalid.")
                    .MustAsync(async (email, cancellation) => ! await authenticationAppService.CheckEmail(email))
                    .WithMessage("This user is already excist.")
                    .MustAsync(async (email, cancellation) =>
                    {

                       bool valid =  b2bDbContext.TravelAgentOffices.Any(x => x.FirstEmail == email)|| 
                                     b2bDbContext.TravelAgentEmployees.Any(x => x.EmployeeEmail == email)||await authenticationAppService.CheckEmail(email); 

                        if (valid) return !valid;
                        var score = await EmailValidation.GetEmailValidationScore(_emailValidationApiKey, email);
                        return score;
                    })
                    .WithMessage("This email is not valid.");


                RuleFor(dto => (dto as TravelAgentEmployeeCreateDto).EmployeeFirstName)
                    .NotEmpty()
                    .WithMessage("The Employee First Name of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentEmployeeCreateDto).EmployeeLastName)
                    .NotEmpty()
                    .WithMessage("The Employee Last Name of the Office cannot be empty.");


                RuleFor(dto => (dto as TravelAgentEmployeeCreateDto).PhoneNumber)
                       .NotEmpty()
                       .WithMessage("Phone number cannot be empty.")
                       .Matches(@"^\+?[1-9]\d{1,14}$")
                       .WithMessage("Phone number must be a valid international format.");


            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as TravelAgentEmployeeUpdateDto).EmployeeEmail)
                    .NotEmpty()
                    .WithMessage("The Email of the Custom Form cannot be empty.")
                    .EmailAddress()
                    .WithMessage("The Email format is invalid.")
                    .MustAsync(async (email, cancellation) => !await authenticationAppService.CheckEmail(email))
                    .WithMessage("This user is already excist.")
                    .MustAsync(async (email, cancellation) =>
                    {

                        bool valid = b2bDbContext.TravelAgentOffices.Any(x => x.FirstEmail == email) ||
                                        b2bDbContext.TravelAgentEmployees.Any(x => x.EmployeeEmail == email) || await authenticationAppService.CheckEmail(email); 

                        if (valid) return !valid;
                        var score = await EmailValidation.GetEmailValidationScore(_emailValidationApiKey, email);
                        return score;
                    })
                    .WithMessage("This email is not valid.");


                RuleFor(dto => (dto as TravelAgentEmployeeUpdateDto).TravelAgentOfficeId)
                    .NotEmpty()
                    .WithMessage("The Travel Agent Office Id cannot be empty.");

                RuleFor(dto => (dto as TravelAgentEmployeeUpdateDto).PhoneNumber)
                    .NotEmpty()
                    .WithMessage("Phone number cannot be empty.")
                    .Matches(@"^\+?[1-9]\d{1,14}$")
                    .WithMessage("Phone number must be a valid international format.");
            });
        }
    }
}
