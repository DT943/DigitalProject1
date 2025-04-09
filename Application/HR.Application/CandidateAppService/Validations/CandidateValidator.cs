using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HR.Data.DbContext;
using Infrastructure.Application.Validations;

namespace HR.Application.CandidateAppService.Validations
{
    public class CandidateValidator : AbstractValidator<IValidatableDto>
    {
        public CandidateValidator(HRDbContext hotelRepository)
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
