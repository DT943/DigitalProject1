using FluentValidation;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Hotel.Data.DbContext;
using Infrastructure.Application.Validations;

namespace Hotel.Application.HotelGalleryAppService.Validations
{
    public class HotelGalleryValidator : AbstractValidator<IValidatableDto>
    {

        HotelDbContext _hotelContext;

        private static readonly string[] AllowedGallery = { "spa", "restaurant", "pool", "gym", "bar","parking", "room"};

        public HotelGalleryValidator(HotelDbContext hotelContext)
        {
            _hotelContext = hotelContext;
            RuleSet("create", () =>
            {

                RuleFor(dto => (dto as HotelGalleryCreateDto).HotelId)
                   .NotEmpty()
                   .WithMessage("The HotelId of the HotelGallery cannot be empty.");

                RuleFor(dto => (dto as HotelGalleryCreateDto).GalleryName)
                    .NotEmpty()
                    .WithMessage("Gallery name cannot be empty.");

                RuleFor(dto => (dto as HotelGalleryCreateDto).GalleryCode)
                    .NotEmpty()
                    .WithMessage("Gallery code cannot be empty.");

                RuleFor(dto => (dto as HotelGalleryCreateDto).GalleryType)
                     .Must(type => AllowedGallery.Contains(type))
                     .WithMessage($"Gallery type must be one of the following: {string.Join(", ", AllowedGallery)}.")
                     .Must(type => type == type.ToLower())
                     .WithMessage("Gallery type must be in lowercase.");
            });
            RuleSet("update", () =>
            {


                RuleFor(dto => (dto as HotelGalleryUpdateDto).GalleryName)
                    .NotEmpty()
                    .WithMessage("Gallery name cannot be empty.");

                RuleFor(dto => (dto as HotelGalleryUpdateDto).GalleryCode)
                    .NotEmpty()
                    .WithMessage("Gallery code cannot be empty.");

                RuleFor(dto => (dto as HotelGalleryUpdateDto).GalleryType)
                     .Must(type => AllowedGallery.Contains(type))
                     .WithMessage($"Gallery type must be one of the following: {string.Join(", ", AllowedGallery)}.")
                     .Must(type => type == type.ToLower())
                     .WithMessage("Gallery type must be in lowercase.");
            });


        }
    }
}