using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gallery.Application.GalleryAppService.Dtos;
using Infrastructure.Application.Validations;

namespace Gallery.Application.GalleryAppService.Validations
{
    public class GalleryValidator: AbstractValidator<IValidatableDto>
    {
        public GalleryValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as GalleryCreateDto).Name)
                    .NotEmpty()
                    .WithMessage("The Name of the gallery cannot be empty.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as GalleryUpdateDto).Name)
                .NotEmpty()
                .WithMessage("The Name of the gallery cannot be empty.");

            });
        }
    }
}
