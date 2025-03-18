using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWCore.Application.POSAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace CWCore.Application.POSAppService.Validations
{
    public class POSValidator : AbstractValidator<IValidatableDto>
    {

        public POSValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as POSCreateDto).Key)
                    .NotEmpty()
                    .WithMessage("The Key of the POS cannot be empty.");

 
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as POSUpdateDto).Key)
                     .NotEmpty()
                     .WithMessage("The Key of the POS cannot be empty.");



            });
        }
    }
}
