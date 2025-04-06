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
            // test
            _galleryRepository = galleryRepository;
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as FileCreateDto).Title)
                    .NotEmpty()
                    .WithMessage("The Name of the File cannot be empty.")
                    .Must(title => title == title.ToLower())
                    .WithMessage("The Title must be in lowercase.");

                RuleFor(dto => (dto as FileCreateDto).AlternativeText)
                    .NotEmpty()
                    .WithMessage("The Alternative Text cannot be empty.")
                    .Must(text => text == null || text == text.ToLower())
                    .WithMessage("AlternativeText must be in lowercase if provided.");

                RuleFor(dto => (dto as FileCreateDto).Caption)
                    .NotEmpty()
                    .WithMessage("The Caption cannot be empty.")
                    .Must(text => text == null || text == text.ToLower())
                    .WithMessage("Caption must be in lowercase if provided.");

                RuleFor(dto => (dto as FileCreateDto).Description)
                    .NotEmpty()
                    .WithMessage("The Description cannot be empty.")
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
                    .NotEmpty()
                    .WithMessage("The Alternative Text of the File cannot be empty.")
                    .Must(text => text == null || text == text.ToLower())
                    .WithMessage("AlternativeText must be in lowercase if provided.");

                RuleFor(dto => (dto as FileUpdateDto).Caption)
                    .NotEmpty()
                    .WithMessage("The Caption of the File cannot be empty.")
                    .Must(text => text == null || text == text.ToLower())
                    .WithMessage("Caption must be in lowercase if provided.");

                RuleFor(dto => (dto as FileUpdateDto).Description)
                    .NotEmpty()
                    .WithMessage("The Description of the File cannot be empty.")
                    .Must(text => text == null || text == text.ToLower())
                    .WithMessage("Description must be in lowercase if provided.");

                RuleFor(dto => (dto as FileUpdateDto).GalleryId)
                   .NotEmpty()
                   .WithMessage("The GalleryId of the File cannot be empty.")
                   .Must(GalleryId => _galleryRepository.Galleries.Any(g => g.Id == GalleryId))
                   .WithMessage("GalleryId not excists");

            });

            RuleSet("multiCreate", () =>
            {
                RuleFor(dto => (dto as MultiFileCreateDto).GalleryCode)
                    .NotEmpty()
                    .WithMessage("Gallery code is required.");

                RuleFor(dto => (dto as MultiFileCreateDto).Files)
                    .NotEmpty()
                    .WithMessage("At least one file is required.")
                    .Must(files => files.All(file => file.File != null && file.File.Length > 0))
                    .WithMessage("All files must be valid and non-empty.");

                RuleForEach(dto => (dto as MultiFileCreateDto).Files).ChildRules(file =>
                {
                    file.RuleFor(f => f.Title)
                        .NotEmpty()
                        .WithMessage("The Name of the File cannot be empty.")
                        .Must(title => title == title.ToLower())
                        .WithMessage("The Title must be in lowercase.");

                    file.RuleFor(f => f.AlternativeText)
                        .NotEmpty()
                        .WithMessage("The Alternative Text cannot be empty.")
                        .Must(text => text == null || text == text.ToLower())
                        .WithMessage("AlternativeText must be in lowercase if provided.");

                    file.RuleFor(f => f.Caption)
                        .NotEmpty()
                        .WithMessage("The Caption cannot be empty.")
                        .Must(text => text == null || text == text.ToLower())
                        .WithMessage("Caption must be in lowercase if provided.");

                    file.RuleFor(f => f.Description)
                        .NotEmpty()
                        .WithMessage("The Description cannot be empty.")
                        .Must(text => text == null || text == text.ToLower())
                        .WithMessage("Description must be in lowercase if provided.");
                });
            });
        }
    }
}
