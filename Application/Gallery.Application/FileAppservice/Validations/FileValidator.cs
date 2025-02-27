using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gallery.Application.FileAppservice.Dtos;
using Infrastructure.Application.Validations;

namespace Gallery.Application.FileAppservice.Validations
{
    public class FileValidator : AbstractValidator<IValidatableDto>
    {
        public FileValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as FileCreateDto).Name)
                    .NotEmpty()
                    .WithMessage("The Name of the gallery cannot be empty.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as FileUpdateDto).Name)
                .NotEmpty()
                .WithMessage("The Name of the gallery cannot be empty.");

            });
        }
    }
}
