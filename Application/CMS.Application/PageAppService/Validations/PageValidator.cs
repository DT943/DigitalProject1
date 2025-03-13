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
        public PageValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as PageCreateDto).Title)
                    .NotEmpty()
                    .WithMessage("The Title of the page cannot be empty.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as PageUpdateDto).Title)
                .NotEmpty()
                .WithMessage("The Title of the page cannot be empty.");

            });
        }
    }
}
