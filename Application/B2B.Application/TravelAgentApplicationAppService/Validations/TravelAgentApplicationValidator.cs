using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.TravelAgentApplicationAppService.Dto;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace B2B.Application.TravelAgentApplicationAppService.Validations
{
    public class TravelAgentApplicationValidator : AbstractValidator<IValidatableDto>
    {
        public TravelAgentApplicationValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as TravelAgentApplicationCreateDto).TravelAgencyName)
                    .NotEmpty()
                    .WithMessage("The Travel Agency Name cannot be empty.");
            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as TravelAgentApplicationUpdateDto).TravelAgencyName)
                    .NotEmpty()
                    .WithMessage("The Travel Agency Name cannot be empty.");
            });
        }
    }
}
