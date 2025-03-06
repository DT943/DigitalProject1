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
                RuleFor(dto => (dto as FileCreateDto).Name)
                    .NotEmpty()
                    .WithMessage("The Name of the gallery cannot be empty.").Must((dto as FileCreateDto) => galleryRepository.Galleries.Find(dto.GalleryId);

                RuleFor(dto => (dto as FileCreateDto).Path)
                   .NotEmpty()
                   .WithMessage("The Path of the gallery cannot be empty.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as FileUpdateDto).Name)
                .NotEmpty()
                .WithMessage("The Name of the gallery cannot be empty.");

                RuleFor(dto => (dto as FileUpdateDto).Path)
               .NotEmpty()
               .WithMessage("The Path of the gallery cannot be empty.");

            });
        }
    }
}
