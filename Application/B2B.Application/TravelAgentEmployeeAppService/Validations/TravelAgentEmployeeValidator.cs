using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace B2B.Application.TravelAgentEmployeeAppService.Validations
{
    public class TravelAgentEmployeeValidator : AbstractValidator<IValidatableDto>
    {
        public TravelAgentEmployeeValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as TravelAgentEmployeeCreateDto).EmployeeEmail)
                    .NotEmpty()
                    .WithMessage("The Employee Email of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentEmployeeCreateDto).EmployeeRole)
                    .NotEmpty()
                    .WithMessage("The Employee Role of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentEmployeeCreateDto).TravelAgentOfficeId)
                    .NotEmpty()
                    .WithMessage("The Travel Agent Office Id cannot be empty.");

                RuleFor(dto => (dto as TravelAgentEmployeeCreateDto).PhoneNumber)
                    .NotEmpty()
                    .WithMessage("The Travel Agent Name of the Office cannot be empty.");
            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as TravelAgentEmployeeUpdateDto).EmployeeEmail)
                    .NotEmpty()
                    .WithMessage("The Employee Email of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentEmployeeUpdateDto).EmployeeRole)
                    .NotEmpty()
                    .WithMessage("The Employee Role of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentEmployeeUpdateDto).TravelAgentOfficeId)
                    .NotEmpty()
                    .WithMessage("The Travel Agent Office Id cannot be empty.");

                RuleFor(dto => (dto as TravelAgentEmployeeUpdateDto).PhoneNumber)
                    .NotEmpty()
                    .WithMessage("The Travel Agent Name of the Office cannot be empty.");
            });
        }
    }
}
