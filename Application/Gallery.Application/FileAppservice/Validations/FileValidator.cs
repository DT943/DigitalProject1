using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Data.DbContext;
using Infrastructure.Application.Validations;

namespace Gallery.Application.FileAppservice.Validations
{
    public class FileValidator : AbstractValidator<IValidatableDto>
    {
        GalleryDbContext _galleryRepository;

        public FileValidator(GalleryDbContext galleryRepository)
        {
            _galleryRepository = galleryRepository;
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as FileCreateDto).Title)
                    .NotEmpty()
                    .WithMessage("The Name of the File cannot be empty.")
                    .Must(title => title == title.ToLower())
                    .WithMessage("The Title must be in lowercase.");

                RuleFor(dto => (dto as FileCreateDto).AlternativeText)
                    .Must(text => text == null || text == text.ToLower())
                    .WithMessage("AlternativeText must be in lowercase if provided.");

                RuleFor(dto => (dto as FileCreateDto).Caption)
                    .Must(text => text == null || text == text.ToLower())
                    .WithMessage("Caption must be in lowercase if provided.");

                RuleFor(dto => (dto as FileCreateDto).Description)
                    .Must(text => text == null || text == text.ToLower())
                    .WithMessage("Description must be in lowercase if provided.");

                RuleFor(dto => (dto as FileCreateDto).GalleryId)
                   .NotEmpty()
                   .WithMessage("The GalleryId of the File cannot be empty.")
                   .Must(GalleryId => _galleryRepository.Galleries.Any(g => g.Id == GalleryId))
                   .WithMessage("GalleryId not excists"); 
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as FileUpdateDto).Title)
                    .NotEmpty()
                    .WithMessage("The Name of the File cannot be empty.")
                    .Must(title => title == title.ToLower())
                    .WithMessage("The Title must be in lowercase.");

                RuleFor(dto => (dto as FileUpdateDto).AlternativeText)
                    .Must(text => text == null || text == text.ToLower())
                    .WithMessage("AlternativeText must be in lowercase if provided.");

                RuleFor(dto => (dto as FileUpdateDto).Caption)
                    .Must(text => text == null || text == text.ToLower())
                    .WithMessage("Caption must be in lowercase if provided.");

                RuleFor(dto => (dto as FileUpdateDto).Description)
                    .Must(text => text == null || text == text.ToLower())
                    .WithMessage("Description must be in lowercase if provided.");

                RuleFor(dto => (dto as FileUpdateDto).GalleryId)
                   .NotEmpty()
                   .WithMessage("The GalleryId of the File cannot be empty.")
                   .Must(GalleryId => _galleryRepository.Galleries.Any(g => g.Id == GalleryId))
                   .WithMessage("GalleryId not excists");

            });
        }
    }
}
