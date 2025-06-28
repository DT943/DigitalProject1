using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWCore.Application.LanguageAppService.Dtos;
using CWCore.Application.POSAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace CWCore.Application.LanguageAppService.Validations
{
    public class LanguageValidator: AbstractValidator<IValidatableDto>
    {

        public LanguageValidator() {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as LanguageCreateDto))
                    .NotNull().WithMessage("Language cannot be null")
                    .DependentRules(() =>
                    {
                        RuleFor(dto => ((LanguageCreateDto)dto).Name)
                            .NotEmpty().WithMessage("Language name is required");

                        RuleFor(dto => ((LanguageCreateDto)dto).LanguageCode)
                            .NotEmpty().WithMessage("Language code is required")
                            .Length(2, 5).WithMessage("Language code must be 2–5 characters");
                    });
            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as LanguageUpdateDto))
                    .NotNull().WithMessage("Language cannot be null")
                    .DependentRules(() =>
                    {
                        RuleFor(dto => ((LanguageUpdateDto)dto).Id)
                            .GreaterThan(0).WithMessage("Invalid language ID");

                        RuleFor(dto => ((LanguageUpdateDto)dto).Name)
                            .NotEmpty().WithMessage("Language name is required");

                        RuleFor(dto => ((LanguageUpdateDto)dto).LanguageCode)
                            .NotEmpty().WithMessage("Language code is required")
                            .Length(2, 5).WithMessage("Language code must be 2–5 characters");
                    });
            });




        }

    }
}
