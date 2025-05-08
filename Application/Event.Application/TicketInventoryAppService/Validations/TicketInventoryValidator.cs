using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Application.TicketInventoryAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace Event.Application.TicketInventoryAppService.Validations
{
    public class TicketInventoryValidator : AbstractValidator<IValidatableDto>
    {

        public TicketInventoryValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as TicketInventoryCreateDto).Status)
                    .NotEmpty()
                    .WithMessage("The Status of the Ticket cannot be empty.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as TicketInventoryUpdateDto).Status)
                     .NotEmpty()
                     .WithMessage("The Status of the Ticket cannot be empty.");
            });
        }
    }
}
