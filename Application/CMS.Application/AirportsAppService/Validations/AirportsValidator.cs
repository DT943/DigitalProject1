using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace CMS.Application.AirportsAppService.Validations
{
    public class AirportsValidator : AbstractValidator<IValidatableDto>
    {

        public AirportsValidator()
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
