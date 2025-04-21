using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.CustomFormAppService.Dto;
using CMS.Data.DbContext;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace CMS.Application.CustomFormAppService.Validations
{
    public class CustomFormValidator : AbstractValidator<IValidatableDto>
    {
        public CustomFormValidator(CMSDbContext cmsDbContext)
        {
            RuleSet("create", () =>
            {

                RuleFor(dto => (dto as CustomFormCreateDto).Email)
                    .NotEmpty()
                    .WithMessage("The Email of the Custom Form cannot be empty.")
                    .EmailAddress()
                    .WithMessage("The Email format is invalid.")
                    .Must((p) => !cmsDbContext.CustomForms.Where(x => p.Equals(x.Email)).Any())
                    .WithMessage("This Email is aready excists.");


                RuleFor(dto => (dto as CustomFormCreateDto).Services)
                    .NotEmpty()
                    .WithMessage("The Services of the Custom Form cannot be empty.");

                RuleFor(dto => (dto as CustomFormCreateDto).PhoneNumber)
                    .NotEmpty()
                    .WithMessage("The Phone Number of the Custom Form cannot be empty.")
                    .Matches(@"^\+?[1-9]\d{1,14}$")
                    .WithMessage("The Phone Number format is invalid."); ;

                RuleFor(dto => (dto as CustomFormCreateDto).Description)
                    .NotEmpty()
                    .WithMessage("The Description of the Custom Form cannot be empty.");

            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as CustomFormCreateDto).Email)
                    .NotEmpty()
                    .WithMessage("The Email of the Custom Form cannot be empty.")
                    .EmailAddress()
                    .WithMessage("The Email format is invalid.")
                    .Must((p) => !cmsDbContext.CustomForms.Where(x => p.Equals(x.Email)).Any())
                    .WithMessage("This Email is aready excists."); ;

                RuleFor(dto => (dto as CustomFormCreateDto).Services)
                    .NotEmpty()
                    .WithMessage("The Services of the Custom Form cannot be empty.");

                RuleFor(dto => (dto as CustomFormCreateDto).PhoneNumber)
                    .NotEmpty()
                    .WithMessage("The Phone Number of the Custom Form cannot be empty.")
                    .Matches(@"^\+?[1-9]\d{1,14}$")
                    .WithMessage("The Phone Number format is invalid."); ;

                RuleFor(dto => (dto as CustomFormCreateDto).Description)
                    .NotEmpty()
                    .WithMessage("The Description of the Custom Form cannot be empty.");


            });
        }
    }
}
