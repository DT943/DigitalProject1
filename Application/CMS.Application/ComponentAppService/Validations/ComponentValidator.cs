using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.ComponentAppService.Dto;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace CMS.Application.ComponentAppService.Validations
{
    public class ComponentValidator : AbstractValidator<IValidatableDto>
    {
        public ComponentValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as ComponentCreateDto).Type)
                    .NotEmpty()
                    .WithMessage("The Type of the Component cannot be empty.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as ComponentCreateDto).Type)
                .NotEmpty()
                .WithMessage("The Type of the Component cannot be empty.");

            });
        }
    }
}
