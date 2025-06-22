using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using TicketIssue.Data.DbContext;

namespace TicketIssue.Application.TicketIssueAppService.Validations
{
    public class TicketIssueValidator : AbstractValidator<IValidatableDto>
    {


        public TicketIssueValidator(TicketIssueDbContext offerDbContext)
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
