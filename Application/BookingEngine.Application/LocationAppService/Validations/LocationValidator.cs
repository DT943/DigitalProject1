using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.LocationAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.LocationAppService.Validations
{
    public class LocationValidator : AbstractValidator<IValidatableDto>
    {

        public LocationValidator()
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
