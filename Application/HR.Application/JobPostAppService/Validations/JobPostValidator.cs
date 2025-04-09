using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HR.Data.DbContext;
using Infrastructure.Application.Validations;

namespace HR.Application.JobPostAppService.Validations
{
    public class JobPostValidator : AbstractValidator<IValidatableDto>
    {
        public JobPostValidator(HRDbContext hotelRepository)
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
