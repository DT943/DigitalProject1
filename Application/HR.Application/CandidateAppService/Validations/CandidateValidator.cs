using FluentValidation;
using HR.Application.CandidateAppService.Dtos;
using HR.Data.DbContext;
using Infrastructure.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.CandidateAppService.Validations
{
    public class CandidateValidator : AbstractValidator<IValidatableDto>
    {

        public CandidateValidator(HRDbContext hotelRepository)
        {
            RuleSet("create", () =>
            {
                RuleFor(x => ((CandidateCreateDto)x).FirstName)
                    .NotEmpty().WithMessage("First name is required.")
                    .MaximumLength(100);

                RuleFor(x => ((CandidateCreateDto)x).LastName)
                    .NotEmpty().WithMessage("Last name is required.")
                    .MaximumLength(100);

                RuleFor(x => ((CandidateCreateDto)x).Email)
                    .NotEmpty().WithMessage("Email is required.")
                    .EmailAddress().WithMessage("Email format is invalid.")
                    .MaximumLength(200);

                RuleFor(x => ((CandidateCreateDto)x).Phone)
                    .NotEmpty().WithMessage("Phone is required.")
                    .MaximumLength(50);

                RuleFor(x => ((CandidateCreateDto)x).JobAppliedFor)
                    .NotEmpty().WithMessage("Job applied for is required.");

                RuleFor(x => ((CandidateCreateDto)x).Motivation)
                    .NotEmpty().WithMessage("Motivation is required.");

            });

            RuleSet("update", () =>
            {
                RuleFor(x => ((CandidateUpdateDto)x).FirstName)
                    .NotEmpty().WithMessage("First name is required.")
                    .MaximumLength(100);

                RuleFor(x => ((CandidateUpdateDto)x).LastName)
                    .NotEmpty().WithMessage("Last name is required.")
                    .MaximumLength(100);

                RuleFor(x => ((CandidateUpdateDto)x).Email)
                    .NotEmpty().WithMessage("Email is required.")
                    .EmailAddress().WithMessage("Email format is invalid.")
                    .MaximumLength(200);

                RuleFor(x => ((CandidateUpdateDto)x).Phone)
                    .NotEmpty().WithMessage("Phone is required.")
                    .MaximumLength(50);

                RuleFor(x => ((CandidateUpdateDto)x).JobAppliedFor)
                    .NotEmpty().WithMessage("Job applied for is required.");

                RuleFor(x => ((CandidateUpdateDto)x).Motivation)
                    .NotEmpty().WithMessage("Motivation is required.");

                RuleFor(x => ((CandidateUpdateDto)x).LinkedIn)
                    .Must(uri => string.IsNullOrWhiteSpace(uri) || Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                    .WithMessage("LinkedIn URL is invalid.");

                RuleFor(x => ((CandidateUpdateDto)x).GitHub)
                    .Must(uri => string.IsNullOrWhiteSpace(uri) || Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                    .WithMessage("GitHub URL is invalid.");

                RuleFor(x => ((CandidateUpdateDto)x).PortfolioUrl)
                    .Must(uri => string.IsNullOrWhiteSpace(uri) || Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                    .WithMessage("Portfolio URL is invalid.");

            });

        }

    }
}
