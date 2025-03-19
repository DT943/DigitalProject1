using FluentValidation;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.RoomAppService.Dtos;
using Hotel.Data.DbContext;
using Infrastructure.Application.Validations;

namespace Hotel.Application.RoomAppService.Validations
{
    public class RoomValidator : AbstractValidator<IValidatableDto>
    {
        HotelDbContext _hotelContext;

        private static readonly string[] AllowedCategory = { "single", "double" };

        public RoomValidator(HotelDbContext hotelContext)
        {
            _hotelContext = hotelContext;
            RuleSet("create", () =>
            {
                
                RuleFor(dto => (dto as RoomCreateDto).HotelId)
                   .NotEmpty()
                   .WithMessage("The HotelId of the Room cannot be empty.")
                   .Must(HotelId => _hotelContext.Hotels.Any(h => h.Id == HotelId))
                   .WithMessage("HotelId not excists");


                RuleFor(dto => (dto as RoomCreateDto).NumberOfAdults)
                    .NotEmpty()
                    .WithMessage("Number of adults cannot be empty.");

                RuleFor(dto => (dto as RoomCreateDto).NumberOfChildren)
                    .NotEmpty()
                    .WithMessage("Number of children cannot be empty.");

                RuleFor(dto => (dto as RoomCreateDto).Category)
                     .Must(type => AllowedCategory.Contains(type))
                     .WithMessage($"Category must be one of the following: {string.Join(", ", AllowedCategory)}.")
                     .Must(type => type == type.ToLower())
                    .WithMessage("The Category must be in lowercase.");
            });

            RuleSet("update", () =>
            {
                
                RuleFor(dto => (dto as RoomUpdateDto).NumberOfAdults)
                    .NotEmpty()
                    .WithMessage("Number of adults cannot be empty.");

                RuleFor(dto => (dto as RoomUpdateDto).NumberOfChildren)
                    .NotEmpty()
                    .WithMessage("Number of children cannot be empty.");

                RuleFor(dto => (dto as RoomUpdateDto).Category)
                     .Must(type => AllowedCategory.Contains(type))
                     .WithMessage($"Category must be one of the following: {string.Join(", ", AllowedCategory)}.")
                     .Must(type => type == type.ToLower())
                    .WithMessage("The Category must be in lowercase.");
            });

        }
    }
}