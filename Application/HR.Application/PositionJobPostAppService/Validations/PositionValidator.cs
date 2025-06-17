using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HR.Application.PositionAppService.Dtos;
using HR.Data.DbContext;
using HR.Domain.Models;
using Infrastructure.Application.Validations;

namespace HR.Application.PositionAppService.Validations
{
    public class PositionValidator : AbstractValidator<IValidatableDto>
    {
        public PositionValidator(HRDbContext hotelRepository)
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
