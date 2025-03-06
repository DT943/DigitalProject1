using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gallery.Application.GalleryAppService.Dtos;
using Gallery.Data.DbContext;
using Infrastructure.Application.Validations;

namespace Gallery.Application.GalleryAppService.Validations
{
    public class GalleryValidator: AbstractValidator<IValidatableDto>
    {
        GalleryDbContext _galleryRepository;
        public GalleryValidator(GalleryDbContext galleryRepository)
        {
            _galleryRepository = galleryRepository;
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as GalleryCreateDto).Name)
                    .NotEmpty()
                    .WithMessage("The Name of the gallery cannot be empty.")
                    .Must((dto, name) => IsUniqueGalleryName(name)) // Custom validation for uniqueness
                    .WithMessage("The Name of the gallery must be unique.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as GalleryUpdateDto).Name)
                .NotEmpty()
                .WithMessage("The Name of the gallery cannot be empty.")
                .Must((dto, name) => IsUniqueGalleryName(name)) // Custom validation for uniqueness
                .WithMessage("The Name of the gallery must be unique.");

            });
        }

        // Method to check uniqueness (you will implement this logic based on your database)
        private bool IsUniqueGalleryName(string name, int? excludeId = null)
        {
            // Example: Use your repository or database context to check if the name exists.
            // If 'excludeId' is provided, exclude that specific gallery from the check
            var galleryExists = _galleryRepository.Galleries
                .Where(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                            (excludeId == null || g.Id != excludeId))
                .Any();
            return !galleryExists;
        }
    }
}
