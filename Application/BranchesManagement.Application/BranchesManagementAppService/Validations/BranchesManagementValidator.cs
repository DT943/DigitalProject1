using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BranchesManagement.Application.BranchesManagementAppService.Dto;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BranchesManagement.Application.BranchesManagementAppService.Validations
{
    public class BranchesManagementValidator : AbstractValidator<IValidatableDto>
    {
        public BranchesManagementValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as BranchesManagementCreateDto).Name)
                    .NotEmpty()
                    .WithMessage("The Name of the  Branches Management cannot be empty.");

                RuleFor(dto => (dto as BranchesManagementCreateDto).OfficeHours)
                    .NotEmpty()
                    .WithMessage("The Office Hours of the  Branches Management cannot be empty.");

                RuleFor(dto => (dto as BranchesManagementCreateDto).EmailAddress)
                    .NotEmpty()
                    .WithMessage("The Email Address of the  Branches Management cannot be empty.");

                RuleFor(dto => (dto as BranchesManagementCreateDto).PhoneNumber)
                    .NotEmpty()
                    .WithMessage("The Phone Number of the  Branches Management cannot be empty.");

                RuleFor(dto => (dto as BranchesManagementCreateDto).Location)
                    .NotEmpty()
                    .WithMessage("The Location of the  Branches Management cannot be empty.");

            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as BranchesManagementUpdateDto).Name)
                    .NotEmpty()
                    .WithMessage("The Name of the  Branches Management cannot be empty.");
                    
                RuleFor(dto => (dto as BranchesManagementUpdateDto).OfficeHours)
                    .NotEmpty()
                    .WithMessage("The Office Hours of the  Branches Management cannot be empty.");

                RuleFor(dto => (dto as BranchesManagementUpdateDto).EmailAddress)
                    .NotEmpty()
                    .WithMessage("The Email Address of the  Branches Management cannot be empty.");

                RuleFor(dto => (dto as BranchesManagementUpdateDto).PhoneNumber)
                    .NotEmpty()
                    .WithMessage("The Phone Number of the  Branches Management cannot be empty.");

                RuleFor(dto => (dto as BranchesManagementUpdateDto).Location)
                    .NotEmpty()
                    .WithMessage("The Location of the  Branches Management cannot be empty.");

            });
        }
    }
}
