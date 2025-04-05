using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Application.EventAppService.Dtos;
using Event.Application.TicketAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace Event.Application.TicketAppService.Validations
{
    public class TicketValidator : AbstractValidator<IValidatableDto>
    {

        public TicketValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as TicketCreateDto))
                    .NotEmpty()
                    .WithMessage("The Key of the POS cannot be empty.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as TicketUpdateDto))
                     .NotEmpty()
                     .WithMessage("The Key of the POS cannot be empty.");
            });
        }
    }
}
