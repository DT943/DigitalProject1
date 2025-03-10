using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.PageAppService.Dtos;
using CMS.Data.DbContext;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace CMS.Application.PageAppService.Validations
{
    public class PageValidator : AbstractValidator<IValidatableDto>
    {
        private readonly CMSDbContext _cmsDbContext;
        public PageValidator(CMSDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as PageCreateDto).Title)
                    .NotEmpty()
                    .WithMessage("The Title of the page cannot be empty.");

                RuleFor(dto => (dto as PageCreateDto))
                    .Must(dto => !checkPageUrl(dto))
                    .WithMessage("A page with the same URL already exists.")
                    .Must(dto => !checkPageParentUrl(dto))
                    .WithMessage("The Parent Url is already excist");

            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as PageUpdateDto).Title)
                .NotEmpty()
                .WithMessage("The Title of the page cannot be empty.");

            });
        }


        public bool checkPageUrl(PageCreateDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.PageUrlName) || string.IsNullOrWhiteSpace(dto.POS) || string.IsNullOrWhiteSpace(dto.Language))
            {
                return false;
            }

            return _cmsDbContext.Pages
                .Where(x =>
                    (x.PageUrlName ?? "").ToLower().Trim('/') == dto.PageUrlName.ToLower().Trim('/') &&
                    (x.POS ?? "").ToLower() == dto.POS.ToLower() &&
                    (x.Language ?? "").ToLower() == dto.Language.ToLower()
                )
                .Any();
        }


        public bool checkPageParentUrl(PageCreateDto dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.PageUrlName) ||
                string.IsNullOrWhiteSpace(dto.POS) || string.IsNullOrWhiteSpace(dto.Language))
                return false;

            // Extract parent URL (e.g., "parent/sun" from "parent/sun/slug")
            var parentUrl = string.Join("/", dto.PageUrlName.Split('/').Take(dto.PageUrlName.Split('/').Length - 1));

            // Check if parent URL exists in the database
            var parentExists = _cmsDbContext.Pages
                .Any(x => x.PageUrlName.Trim().ToLower() == parentUrl.Trim().ToLower() &&
                          x.POS.Trim().ToLower() == dto.POS.Trim().ToLower() &&
                          x.Language.Trim().ToLower() == dto.Language.Trim().ToLower());

            // Ensure the parent exists and we are not trying to add a single-level page (e.g., "parent")
            var isSingleLevel = dto.PageUrlName.Split('/').Length == 1;

            if (parentExists && !isSingleLevel)
            {
                return true; // Parent exists and we're adding a valid child URL
            }

            return false; // Parent doesn't exist or the URL is a single level
        }


    }
}
