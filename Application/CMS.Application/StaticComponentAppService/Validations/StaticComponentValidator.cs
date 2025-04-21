using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.ComponentAppService.Dto;
using CMS.Application.StaticComponentAppService.Dto;
using CMS.Data.DbContext;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace CMS.Application.StaticComponentAppService.Validations
{
    public class StaticComponentValidator : AbstractValidator<IValidatableDto>
    {
        private static readonly string[] AllowedTypes = { "header", "footer" };

        public StaticComponentValidator(CMSDbContext _cmsDbContext)
        {

            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as StaticComponentCreateDto).Type)
                  .Must(x => !_cmsDbContext.StaticComponents.Any(y => y.Type.ToLower().Equals(x)))
                    .WithMessage("The Type of the Component is already excists")
                    .NotEmpty()
                    .WithMessage("The Type of the Component cannot be empty.")
                    .Must(type => AllowedTypes.Contains(type))
                    .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.");

                RuleFor(dto => (dto as StaticComponentCreateDto).Content)
                    .NotEmpty()
                    .WithMessage("The Content of the Component cannot be empty.")
                    .Must(BeValidJson)
                    .WithMessage("The Content must be a valid JSON.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as StaticComponentUpdateDto).Type) 
                .NotEmpty()
                .WithMessage("The Type of the Component cannot be empty.")
                .Must(type => AllowedTypes.Contains(type))
                .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.");



                RuleFor(dto => (dto as StaticComponentUpdateDto))
                  .Must(x => !_cmsDbContext.StaticComponents.Any(y => y.Type.ToLower().Equals(x.Type) && y.Id !=x.Id  ))
                  .WithMessage("The Type of the Component is already excists");



                RuleFor(dto => (dto as StaticComponentUpdateDto).Content)
                .NotEmpty()
                .WithMessage("The Content of the Component cannot be empty.")
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
