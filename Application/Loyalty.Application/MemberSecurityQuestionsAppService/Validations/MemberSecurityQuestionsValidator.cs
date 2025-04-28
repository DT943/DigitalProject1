using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using Loyalty.Data.DbContext;

namespace Loyalty.Application.MemberSecurityQuestionsAppService.Validations
{
    public class MemberSecurityQuestionsValidator : AbstractValidator<IValidatableDto>
    {
        public MemberSecurityQuestionsValidator(LoyaltyDbContext loyaltyRepository)
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
