using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HR.Application.JobPostAppService.Dtos;
using HR.Data.DbContext;
using HR.Domain.Models;
using Infrastructure.Application.Validations;

namespace HR.Application.JobPostAppService.Validations
{
    public class JobPostValidator : AbstractValidator<IValidatableDto>
    {
        public JobPostValidator(HRDbContext hotelRepository)
        {
            RuleSet("create", () =>
            {
                RuleFor(x => ((JobPostCreateDto)x).JobTitle)
                    .NotEmpty().WithMessage("Job title is required.")
                    .MaximumLength(150).WithMessage("Job title must not exceed 150 characters.");

                RuleFor(x => ((JobPostCreateDto)x).Department)
                    .MaximumLength(100).WithMessage("Department must not exceed 100 characters.");

                RuleFor(x => ((JobPostCreateDto)x).Location)
                    .MaximumLength(100).WithMessage("Location must not exceed 100 characters.");

                RuleFor(x => ((JobPostCreateDto)x).JobType)
                    .MaximumLength(50).WithMessage("Job type must not exceed 50 characters.");

                RuleFor(x => ((JobPostCreateDto)x).Status)
                    .MaximumLength(50).WithMessage("Status must not exceed 50 characters.");
                
                RuleFor(x => ((JobPostCreateDto)x))
                    .Must(dto => dto.ClosingDate > DateTime.UtcNow)
                    .WithMessage("Closing date must be after the publish date.");

                RuleFor(x => ((JobPostCreateDto)x).Requirements)
                    .MaximumLength(4000).WithMessage("Requirements must not exceed 4000 characters.");

                RuleFor(x => ((JobPostCreateDto)x).Responsibilities)
                    .MaximumLength(4000).WithMessage("Responsibilities must not exceed 4000 characters.");

                RuleFor(x => ((JobPostCreateDto)x).EmploymentLevel)
                    .MaximumLength(100).WithMessage("Employment level must not exceed 100 characters.");

                RuleFor(x => ((JobPostCreateDto)x).HRContactEmail)
                    .EmailAddress().WithMessage("Invalid email format.")
                    .When(x => !string.IsNullOrWhiteSpace(((JobPostCreateDto)x).HRContactEmail));
            });

            RuleSet("update", () =>
            {
                RuleFor(x => ((JobPostUpdateDto)x).JobTitle)
                    .NotEmpty().WithMessage("Job title is required.")
                    .MaximumLength(150).WithMessage("Job title must not exceed 150 characters.");

                RuleFor(x => ((JobPostUpdateDto)x).Department)
                    .MaximumLength(100).WithMessage("Department must not exceed 100 characters.");

                RuleFor(x => ((JobPostUpdateDto)x).Location)
                    .MaximumLength(100).WithMessage("Location must not exceed 100 characters.");

                RuleFor(x => ((JobPostUpdateDto)x).JobType)
                    .MaximumLength(50).WithMessage("Job type must not exceed 50 characters.");

                RuleFor(x => ((JobPostUpdateDto)x).Status)
                    .MaximumLength(50).WithMessage("Status must not exceed 50 characters.");

                RuleFor(x => ((JobPostUpdateDto)x))
                    .Must(dto => dto.ClosingDate > DateTime.UtcNow)
                    .WithMessage("Closing date must be after the publish date.");

                RuleFor(x => ((JobPostUpdateDto)x).Requirements)
                .MaximumLength(4000).WithMessage("Requirements must not exceed 4000 characters.");

                RuleFor(x => ((JobPostUpdateDto)x).Responsibilities)
                    .MaximumLength(4000).WithMessage("Responsibilities must not exceed 4000 characters.");

                RuleFor(x => ((JobPostUpdateDto)x).EmploymentLevel)
                    .MaximumLength(100).WithMessage("Employment level must not exceed 100 characters.");

                RuleFor(x => ((JobPostUpdateDto)x).HRContactEmail)
                    .EmailAddress().WithMessage("Invalid email format.")
                    .When(x => !string.IsNullOrWhiteSpace(((JobPostUpdateDto)x).HRContactEmail));
            });
        }
    }
}
