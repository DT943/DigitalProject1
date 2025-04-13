using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.B2BAppService.Dto;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace B2B.Application.B2BAppService.Validations
{
    public class TravelAgentOfficeValidator : AbstractValidator<IValidatableDto>
    {
        public TravelAgentOfficeValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).Governate)
                    .NotEmpty()
                    .WithMessage("The Governate of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).POS)
                    .NotEmpty()
                    .WithMessage("The POS cannot of the Office be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).FirstEmail)
                    .NotEmpty()
                    .WithMessage("The Email Address of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).TravelAgentNameISA)
                    .NotEmpty()
                    .WithMessage("TheTravel Agent Name of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).SYD)
                    .NotEmpty()
                    .WithMessage("The Foriegn Currency of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).SYP)
                    .NotEmpty()
                    .WithMessage("The Local Currency of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeCreateDto).UserCode)
                    .NotEmpty()
                    .WithMessage("The Local Currency of the Office cannot be empty.");

            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).Governate)
                    .NotEmpty()
                    .WithMessage("The Governate of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).POS)
                    .NotEmpty()
                    .WithMessage("The POS cannot of the Office be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).TravelAgentNameISA)
                    .NotEmpty()
                    .WithMessage("TheTravel Agent Name of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).SYD)
                    .NotEmpty()
                    .WithMessage("The Foriegn Currency of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).SYP)
                    .NotEmpty()
                    .WithMessage("The Local Currency of the Office cannot be empty.");

                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).UserCode)
                    .NotEmpty()
                    .WithMessage("The Local Currency of the Office cannot be empty.");


                RuleFor(dto => (dto as TravelAgentOfficeUpdateDto).FirstEmail)
                  .NotEmpty()
                  .WithMessage("The Email Address of the Office cannot be empty.");

            });
        }
    }
}
