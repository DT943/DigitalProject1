using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Hotel.Application.HotelAppService.Dtos;
using Infrastructure.Application.Validations;

namespace Hotel.Application.HotelAppService.Validations
{
    public class HotelValidator  :AbstractValidator<IValidatableDto>
    {
    }
}
