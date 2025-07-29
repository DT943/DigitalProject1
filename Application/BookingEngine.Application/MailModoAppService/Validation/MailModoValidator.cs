using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.MailModoAppService.Validation
{
    public class MailModoValidator : AbstractValidator<IValidatableDto>
    {
        public MailModoValidator()
        {
        }

    }
}

