﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using Loyalty.Data.DbContext;

namespace Loyalty.Application.MemberTravelAgentDetailsAppService.Validations
{
    public class MemberTravelAgentDetailsValidator : AbstractValidator<IValidatableDto>
    {
        public MemberTravelAgentDetailsValidator(LoyaltyDbContext loyaltyRepository)
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
