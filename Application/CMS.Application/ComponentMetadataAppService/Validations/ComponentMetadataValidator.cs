using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.ComponentMetadataAppService.Dto;
using CMS.Data.DbContext;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace CMS.Application.ComponentMetadataAppService.Validations
{
    public class ComponentMetadataValidator : AbstractValidator<IValidatableDto>
    {
        public ComponentMetadataValidator(CMSDbContext _cmsDbContext)
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as ComponentMetadataCreateDto).Type)
                    .Must(x => !_cmsDbContext.StaticComponents.Any(y => y.Type.ToLower().Equals(x)))
                    .WithMessage("The Type of the Component is already excists")
                    .NotEmpty()
                    .WithMessage("The Type of the Component cannot be empty.");

                RuleFor(dto => (dto as ComponentMetadataCreateDto).Content)
                    .NotEmpty()
                    .WithMessage("The Type of the Component cannot be empty.")
                    .Must(BeValidJson)
                    .WithMessage("The Content must be a valid JSON.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as ComponentMetadataUpdateDto).Type)
                .NotEmpty()
                .WithMessage("The Type of the Component cannot be empty.");

                RuleFor(dto => (dto as ComponentMetadataUpdateDto).Content)
                .NotEmpty()
                .WithMessage("The Type of the Component cannot be empty.")
                .Must(BeValidJson)
                .WithMessage("The Content must be a valid JSON.");

            });
    }
        private bool BeValidJson(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return false;

            try
            {
                var token = Newtonsoft.Json.Linq.JToken.Parse(content);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
