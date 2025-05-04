using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.ComponentAppService.Dto;
using CMS.Application.ComponentAppService.Validations;
using CMS.Application.PageAppService.Dtos;
using CMS.Application.SegmentAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace CMS.Application.SegmentAppService.Validations
{
    public class SegmentValidator : AbstractValidator<IValidatableDto>
    {
        public SegmentValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as SegmentCreateDto).Name)
                    .NotEmpty()
                    .WithMessage("The Name of the page cannot be empty.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as SegmentUpdateDto).Name)
                .NotEmpty()
                .WithMessage("The Name of the page cannot be empty.");

               /* RuleForEach(dto => (dto as SegmentUpdateDto).Components)
                    .SetValidator(new ComponentValidator());*/

            });
        }
    }
}
