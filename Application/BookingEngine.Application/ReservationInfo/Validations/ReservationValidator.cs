using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.ReservationInfo.Dtos;
using FluentValidation;

namespace BookingEngine.Application.ReservationInfo.Validations
{
    public class ReservationValidator : AbstractValidator<ReservationCreateDto>
    {
        public ReservationValidator()
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
