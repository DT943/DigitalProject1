using FluentValidation;
using Hotel.Application.RoomAppService.Dtos;
using Infrastructure.Application.Validations;

namespace Hotel.Application.RoomAppService.Validations
{
    public class RoomValidator : AbstractValidator<IValidatableDto>
    {
        public RoomValidator()
        {
            //RuleFor(x => x.HotelId).NotEmpty();
            //RuleFor(x => x.Category).NotEmpty().MaximumLength(50);
            //RuleFor(x => x.NumberOfAdults).GreaterThan(0);
            //RuleFor(x => x.NumberOfChildren).GreaterThanOrEqualTo(0);
        }
    }
}