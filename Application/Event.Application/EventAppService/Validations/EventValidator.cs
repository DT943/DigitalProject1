using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Application.EventAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace Event.Application.EventAppService.Validations
{
    public class EventValidator : AbstractValidator<IValidatableDto>
    {

        public EventValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as EventCreateDto))
                    .NotEmpty()
                    .WithMessage("The Key of the POS cannot be empty.");


            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as EventUpdateDto))
                     .NotEmpty()
                     .WithMessage("The Key of the POS cannot be empty.");



            });
        }
    }
}
