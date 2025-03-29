using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Hotel.Application.ContractAppService.Dtos;
using Infrastructure.Application.Validations;

namespace Hotel.Application.ContractAppService.Validations
{
    public class ContractValidator : AbstractValidator<IValidatableDto>
    {
        public ContractValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as ContractCreateDto).ContractFileUrl)
                    .NotEmpty()
                    .WithMessage("The ContractFileUrl   cannot be empty.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as ContractUpdateDto).ContractFileUrl)
                    .NotEmpty()
                    .WithMessage("The ContractFileUrl   cannot be empty.");

            });
        }
    }
}


