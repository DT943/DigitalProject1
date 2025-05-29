using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using Loyalty.Data.DbContext;

namespace Loyalty.Application.MemberTierDetailsAppService.Validations
{
    public class MemberTierDetailsValidator : AbstractValidator<IValidatableDto>
    {
        public MemberTierDetailsValidator(LoyaltyDbContext loyaltyRepository)
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
