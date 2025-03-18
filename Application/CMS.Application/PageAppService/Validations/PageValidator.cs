using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.PageAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace CMS.Application.PageAppService.Validations
{
    public class PageValidator : AbstractValidator<IValidatableDto>
    {
        private static readonly string[] AllowedTypes = { "published", "draft" };

        public PageValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as PageCreateDto).Title)
                    .NotEmpty()
                    .WithMessage("The Title of the page cannot be empty.");


                RuleFor(dto => (dto as PageCreateDto).Status)
                     .Must(type => AllowedTypes.Contains(type))
                     .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.")
                     .Must(type => type == type.ToLower())
                    .WithMessage("The type must be in lowercase.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as PageUpdateDto).Title)
                 .NotEmpty()
                 .WithMessage("The Title of the page cannot be empty.");

                RuleFor(dto => (dto as PageUpdateDto).Status)
                 .Must(type => AllowedTypes.Contains(type))
                 .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.")
                 .Must(type => type == type.ToLower())
                 .WithMessage("The type must be in lowercase.");

            });
        }
    }
}
