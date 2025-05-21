using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace B2B.Application.ReservationAppService.Validations
{
    public class ReservationValidator : AbstractValidator<IValidatableDto>
    {

        public ReservationValidator()
        {
            RuleSet("create", () =>
            {
            });

            RuleSet("update", () =>
            {

            });
        }
    }
}
