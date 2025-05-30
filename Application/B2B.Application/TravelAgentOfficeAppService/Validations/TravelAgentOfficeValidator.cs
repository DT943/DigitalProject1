﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Application;
using B2B.Application.TravelAgentEmployeeAppService.Validations;
using B2B.Application.TravelAgentOffice.Dto;
using B2B.Data.DbContext;
using CWCore.Application.POSAppService;
using FluentValidation;
using Infrastructure.Application.EmailValidation;
using Infrastructure.Application.Validations;
using Microsoft.Extensions.Configuration;

namespace B2B.Application.TravelAgentOffice.Validations
{
     public class TravelAgentOfficeValidator : AbstractValidator<IValidatableDto>
    {
        public TravelAgentOfficeValidator(TravelAgentEmployeeValidator employeeValidator, B2BDbContext b2bDbContext, IConfiguration configuration, IPOSAppService appService, IAuthenticationAppService authenticationAppService)
        {
            string _emailValidationApiKey = configuration["EmailValidation:ApiKey"];

            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).Governate)
                    .NotEmpty()
                    .WithMessage("The Governate of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).POS)
                    .NotEmpty()
                    .WithMessage("The POS cannot of the Office be empty.")
                    .NotEmpty()
                    .WithMessage("The POS cannot be empty.")
                    .Must(type => type == type.ToLower())
                    .WithMessage("The POS must be in lowercase.")
                    .MustAsync(async (pos, cancellation) =>
                    {
                        var result = await appService.GetByPOSKey(pos);
                        return result != null && result.Count() != 0;
                    })
                    .WithMessage("POS is not valid");

                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).FirstEmail)
                    .NotEmpty()
                    .WithMessage("The Email cannot be empty.")
                    .EmailAddress()
                    .WithMessage("The Email format is invalid.")
                    .MustAsync(async (email, cancellation) =>
                    {
                        var score = await authenticationAppService.CheckEmail(email);
                        return !score;
                    })
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

                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).FirstName)
                    .NotEmpty()
                    .WithMessage("The First Name of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).LastName)
                    .NotEmpty()
                    .WithMessage("The Last Name of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).TravelAgentNameISA)
                    .NotEmpty()
                    .WithMessage("TheTravel Agent Name of the Office cannot be empty.");


                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).TravelAgentPOSs)
                    .NotEmpty()
                    .WithMessage("TheTravel Agent Name of the Office cannot be empty.");

                RuleForEach(dto => (dto as TravelAgentOfficeCreateDto).TravelAgentEmployees)
                    .SetValidator(employeeValidator);
            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).Governate)
                    .NotEmpty()
                    .WithMessage("The Governate of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).POS)
                    .NotEmpty()
                    .WithMessage("The POS cannot of the Office be empty.")
                    .NotEmpty()
                    .WithMessage("The POS cannot be empty.")
                    .Must(type => type == type.ToLower())
                    .WithMessage("The POS must be in lowercase.")
                    .MustAsync(async (pos, cancellation) =>
                    {
                        var result = await appService.GetByPOSKey(pos);
                        return result != null && result.Count() != 0;
                    })
                    .WithMessage("POS is not valid");

                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).TravelAgentNameISA)
                    .NotEmpty()
                    .WithMessage("TheTravel Agent Name of the Office cannot be empty.");
 
                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).FirstEmail)
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

                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).FirstName)
                    .NotEmpty()
                    .WithMessage("The First Name of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).LastName)
                    .NotEmpty()
                    .WithMessage("The Last Name of the Office cannot be empty.");

                RuleForEach(dto => (dto as TravelAgentOfficeUpdateDto).TravelAgentEmployees)
                  .SetValidator(employeeValidator);

            });
        }
    }
}
