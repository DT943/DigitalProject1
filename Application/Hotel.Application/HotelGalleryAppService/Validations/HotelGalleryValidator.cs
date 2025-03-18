using FluentValidation;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Infrastructure.Application.Validations;

namespace Hotel.Application.HotelGalleryAppService.Validations
{
    public class HotelGalleryValidator : AbstractValidator<IValidatableDto>
    {
        public HotelGalleryValidator()
        {
            //RuleFor(x => x.HotelId).NotEmpty();
            //RuleFor(x => x.MainGalleryId).NotEmpty();
            //RuleFor(x => x.RoomsGalleryId).NotEmpty();
            //RuleFor(x => x.GymGalleryId).NotEmpty();
            //RuleFor(x => x.SpaGalleryId).NotEmpty();
        }
    }
}