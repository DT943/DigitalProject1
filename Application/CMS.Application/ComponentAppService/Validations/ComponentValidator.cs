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

                RuleFor(dto => (dto as ComponentCreateDto).Content)
                    .NotEmpty()
                    .WithMessage("The Content of the Component cannot be empty.")
                    .Must(BeValidJson)
                    .WithMessage("The Content must be a valid JSON.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as ComponentUpdateDto).Type)
                .NotEmpty()
                .WithMessage("The Type of the Component cannot be empty.");

                RuleFor(dto => (dto as ComponentUpdateDto).Content)
                .NotEmpty()
                .WithMessage("The Content of the Component cannot be empty.")
                .Must(BeValidJson)
                .WithMessage("The Content must be a valid JSON."); 

            });
        }

        private bool BeValidJson(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return false;

            try
            {
                var token = Newtonsoft.Json.Linq.JToken.Parse(content);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
