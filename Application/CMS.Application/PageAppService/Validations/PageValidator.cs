using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.ComponentAppService.Validations;
using CMS.Application.PageAppService.Dtos;
using CMS.Application.SegmentAppService.Dtos;
using CMS.Application.SegmentAppService.Validations;
using CMS.Data.DbContext;
using CWCore.Application.POSAppService;
using CWCore.Domain.Models;
using FluentValidation;
using Infrastructure.Application.Validations;
using Microsoft.EntityFrameworkCore;

namespace CMS.Application.PageAppService.Validations
{
    public class PageValidator : AbstractValidator<IValidatableDto>
    {
        private static readonly string[] AllowedTypes = { "published", "draft" };
        private static readonly string[] AllowedLangTypes = { "arabic", "english" };

        IPOSAppService _appService;
        CMSDbContext _CMSRepository;

        public PageValidator(IPOSAppService appService, CMSDbContext CMSRepository)
        {
            _appService = appService;
            _CMSRepository = CMSRepository;
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as PageCreateDto).Title)
                    .NotEmpty()
                    .WithMessage("The Title of the page cannot be empty.");

                RuleFor(dto => (dto as PageCreateDto).PageUrlName)
                    .NotEmpty()
                    .WithMessage("The page url cannot be empty")
                    .Matches(@"^([a-zA-Z0-9_-]+)(/[a-zA-Z0-9_-]+)*$")
                    .WithMessage("Invalid URL format. Avoid leading/trailing slashes, empty segments, or special characters.")
                    .Must(type => type == type.ToLower())
                    .WithMessage("The page url must be in lowercase.");


                RuleFor(dto => (dto as PageCreateDto).Description)
                    .NotEmpty()
                    .WithMessage("The page url cannot be empty") 
                    .Must(type => type == type.ToLower())
                    .WithMessage("The page url must be in lowercase.");

                RuleFor(dto => (dto as PageCreateDto))
                    .MustAsync(async (dto, cancellation) =>
                    {
                        // Normalize and extract parent path
                        var trimmed = dto.PageUrlName.Trim('/');
                        var segments = trimmed.Split('/', StringSplitOptions.RemoveEmptyEntries);

                        if (segments.Length <= 1)
                            return true; // No parent path to check

                        // Get the parent path (everything except the last segment)
                        var parentPath = string.Join('/', segments.Take(segments.Length - 1)).ToLower();
                        return await CMSRepository.Pages.Where(x => x.Language.ToLower().Equals(dto.Language.ToLower())
                        && x.POS.ToLower().Equals(dto.POS.ToLower())
                        && x.PageUrlName.ToLower().Equals(parentPath.ToLower())).AnyAsync();
                      
                    })
                    .WithMessage("The specified parent path does not exist.")
                    .MustAsync(async (dto, cancellation) =>
                        {
                            return !await CMSRepository.Pages.Where(x => x.Language.ToLower().Equals(dto.Language.ToLower())
                        && x.POS.ToLower().Equals(dto.POS.ToLower())
                        && x.PageUrlName.ToLower().Equals(dto.PageUrlName.ToLower())).AnyAsync();
                        })
                    .WithMessage("The Page Url Name is already Exist"); ;

                RuleFor(dto => (dto as PageCreateDto).Language)
                    .NotEmpty()
                    .WithMessage("The Language cannot be empty")
                    .Must(Language => Language == Language.ToLower())
                    .WithMessage("The page url must be in lowercase.")
                    .Must(type => AllowedLangTypes.Contains(type))
                    .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedLangTypes)}.");

                RuleFor(dto => (dto as PageCreateDto).POS)
                    .NotEmpty()
                    .WithMessage("The POS cannot be empty.")
                    .Must(type => type == type.ToLower())
                    .WithMessage("The POS must be in lowercase.")
                    .MustAsync(async (pos, cancellation) =>
                        {
                            var result = await _appService.GetByPOSKey(pos);
                            return result != null && result.Count() != 0;
                        })
                    .WithMessage("POS is not valid");


                RuleFor(dto => (dto as PageCreateDto).Status)
                     .Must(type => AllowedTypes.Contains(type))
                     .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.")
                     .Must(type => type == type.ToLower())
                     .WithMessage("The type must be in lowercase.");
            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as PageUpdateDto).Title)
                    .NotEmpty()
                    .WithMessage("The Title of the page cannot be empty.");
   

                RuleFor(dto => (dto as PageUpdateDto).Description)
                    .NotEmpty()
                    .WithMessage("The page url cannot be empty")
                    .Must(type => type == type.ToLower())
                    .WithMessage("The page url must be in lowercase.");
  

                RuleFor(dto => (dto as PageUpdateDto).Status)
                     .Must(type => AllowedTypes.Contains(type))
                     .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.")
                     .Must(type => type == type.ToLower())
                     .WithMessage("The type must be in lowercase.");

                RuleForEach(dto => (dto as PageUpdateDto).Segments)
                    .SetValidator(new SegmentValidator());

            });
        }
    }
}
