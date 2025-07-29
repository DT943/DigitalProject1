using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.GalleryAppService.Dtos;
using Gallery.Data.DbContext;
using Infrastructure.Application.Validations;

namespace Gallery.Application.GalleryAppService.Validations
{
    public class GalleryValidator: AbstractValidator<IValidatableDto>
    {
        private static readonly string[] AllowedTypes = { "hotel", "general", "passport", "ticket"};

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
                    .WithMessage("The Name of the gallery must be unique.")
                    .Must(name => name == null || name == name.ToLower())
                    .WithMessage("Name must be in lowercase if provided.");

                RuleFor(dto => (dto as GalleryCreateDto).Description)
                    .NotEmpty()
                    .WithMessage("The Description of the Gallery cannot be empty.")
                    .Must(Description => Description == null || Description == Description.ToLower())
                    .WithMessage("Description must be in lowercase if provided.");


               RuleFor(dto => (dto as GalleryCreateDto).Type)
                    .NotEmpty()
                    .WithMessage("The Type of the Gallery cannot be empty.")
                    .Must(type => AllowedTypes.Contains(type))
                    .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.")
                    .Must(Type => Type == null || Type == Type.ToLower())
                    .WithMessage("Type must be in lowercase if provided.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as GalleryUpdateDto).Name)
                .NotEmpty()
                .WithMessage("The Name of the gallery cannot be empty.")
                .Must((dto, name) => IsUniqueGalleryName(name)) // Custom validation for uniqueness
                .WithMessage("The Name of the gallery must be unique.")
                .Must(name => name == null || name == name.ToLower())
                .WithMessage("Name must be in lowercase if provided.");

                RuleFor(dto => (dto as GalleryUpdateDto).Description)
                    .NotEmpty()
                    .WithMessage("The Description of the Gallery cannot be empty.")
                    .Must(Description => Description == null || Description == Description.ToLower())
                    .WithMessage("Description must be in lowercase if provided.");

                RuleFor(dto => (dto as GalleryUpdateDto).Type)
                     .NotEmpty()
                     .WithMessage("The Type of the Gallery cannot be empty.")
                     .Must(type => AllowedTypes.Contains(type))
                     .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.")
                     .Must(Type => Type == null || Type == Type.ToLower())
                     .WithMessage("Type must be in lowercase if provided.");

            });
        }

        // Method to check uniqueness (you will implement this logic based on your database)
        private bool IsUniqueGalleryName(string name, int? excludeId = null)
        {
            // Convert the name to lowercase and compare
            var galleryExists = _galleryRepository.Galleries
                .Where(g => g.Name.ToLower() == name.ToLower() &&
                            (excludeId == null || g.Id != excludeId))
                .Any();
            return !galleryExists;
        }
    }
}
