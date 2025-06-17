using FluentValidation;
using HR.Application.CandidateAppService.Dtos;
using HR.Data.DbContext;
using Infrastructure.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.CandidateAppService.Validations
{
    public class ApplicationValidator : AbstractValidator<IValidatableDto>
    {

        public ApplicationValidator(HRDbContext hotelRepository)
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
