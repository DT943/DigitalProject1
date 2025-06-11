using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace CMS.Application.TravelUpdatesAppService.Validations
{
    public class TravelUpdatesValidator : AbstractValidator<IValidatableDto>
    {

        public TravelUpdatesValidator()
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
