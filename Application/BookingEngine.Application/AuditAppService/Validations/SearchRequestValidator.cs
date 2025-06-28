using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.AuditAppService.Validations
{
    public class SearchRequestValidator: AbstractValidator<IValidatableDto>
    {

        public SearchRequestValidator()
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
