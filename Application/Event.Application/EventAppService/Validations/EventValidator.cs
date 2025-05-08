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
                RuleFor(dto => (dto as EventCreateDto).Title)
                    .NotEmpty()
                    .WithMessage("The Title of the Event cannot be empty.");

                RuleFor(dto => (dto as EventCreateDto).Description)
                    .NotEmpty()
                    .WithMessage("The Description of the Event cannot be empty.");

                RuleFor(dto => (dto as EventCreateDto).City)
                     .NotEmpty()
                     .WithMessage("The City of the Event cannot be empty.");

                RuleFor(dto => (dto as EventCreateDto).Country)
                     .NotEmpty()
                     .WithMessage("The Country of the Event cannot be empty.");

                RuleFor(dto => (dto as EventCreateDto).Category)
                     .NotEmpty()
                     .WithMessage("The Category of the Event cannot be empty.");

                RuleFor(dto => (dto as EventCreateDto).Address)
                     .NotEmpty()
                     .WithMessage("The Address of the Event cannot be empty.");

                RuleFor(dto => (dto as EventCreateDto).Rank)
                        .NotNull()
                        .InclusiveBetween(1, 5)
                        .WithMessage("The Rank of the Event must be between 1 and 5.");


            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as EventUpdateDto).Title)
                    .NotEmpty()
                    .WithMessage("The Title of the Event cannot be empty.");

                RuleFor(dto => (dto as EventUpdateDto).Description)
                    .NotEmpty()
                    .WithMessage("The Description of the Event cannot be empty.");

                RuleFor(dto => (dto as EventUpdateDto).City)
                     .NotEmpty()
                     .WithMessage("The City of the Event cannot be empty.");

                RuleFor(dto => (dto as EventUpdateDto).Country)
                     .NotEmpty()
                     .WithMessage("The Country of the Event cannot be empty.");

                RuleFor(dto => (dto as EventUpdateDto).Category)
                     .NotEmpty()
                     .WithMessage("The Category of the Event cannot be empty.");


                RuleFor(dto => (dto as EventUpdateDto).Address)
                     .NotEmpty()
                     .WithMessage("The Address of the Event cannot be empty.");

                RuleFor(dto => (dto as EventUpdateDto).Rank)
                        .NotNull()
                        .InclusiveBetween(1, 5)
                        .WithMessage("The Rank of the Event must be between 1 and 5.");



            });
        }
    }
}
