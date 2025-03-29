using FluentValidation;
using Hotel.Application.ContactInfoAppService.Dtos;
using Hotel.Application.HotelAppService.Dtos;
using Infrastructure.Application.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.ContactInfoAppService.Validations
{
    public class ContactInfoValidator : AbstractValidator<IValidatableDto>
    {
        public ContactInfoValidator()
        {
        RuleSet("create", () =>
        {
            RuleFor(dto => (dto as ContactInfoCreateDto).Category)
                .NotEmpty()
                .WithMessage("Category is required")
                .Must(type => type == "website" || type == "contact")
                .WithMessage("Category must be either 'website' or 'contact'");

            RuleFor(dto => (dto as ContactInfoCreateDto).ContactType)
                .NotEmpty()
                .WithMessage("Contact Type is required");

            RuleFor(dto => (dto as ContactInfoCreateDto).PhoneNumber)
                .NotEmpty()
                .When(dto => (dto as ContactInfoCreateDto).Category == "contact")
                .WithMessage("Phone number is required for contact category")
                .Length(10, 15)
                .WithMessage("Phone number must be between 10 and 15 characters long")
                .Must(phone => phone.All(char.IsDigit))
                .WithMessage("Phone number must only contain digits");

            RuleFor(dto => (dto as ContactInfoCreateDto).Url)
                .NotEmpty()
                .When(dto => (dto as ContactInfoCreateDto).Category == "website")
                .WithMessage("URL is required for website category")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Invalid URL format");

            RuleFor(dto => (dto as ContactInfoCreateDto).Email)
                .EmailAddress()
                .WithMessage("Invalid email format");
        });

        RuleSet("update", () =>
        {

            RuleFor(dto => (dto as ContactInfoUpdateDto).Category)
                  .NotEmpty()
                  .WithMessage("Category is required")
                  .Must(type => type == "website" || type == "contact")
                  .WithMessage("Category must be either 'website' or 'contact'");

            RuleFor(dto => (dto as ContactInfoUpdateDto).ContactType)
                .NotEmpty()
                .WithMessage("Contact Type is required");

            RuleFor(dto => (dto as ContactInfoUpdateDto).PhoneNumber)
                .NotEmpty()
                .When(dto => (dto as ContactInfoUpdateDto).Category == "contact")
                .WithMessage("Phone number is required for contact category")
                .Length(10, 15)
                .WithMessage("Phone number must be between 10 and 15 characters long")
                .Must(phone => phone.All(char.IsDigit))
                .WithMessage("Phone number must only contain digits");

            RuleFor(dto => (dto as ContactInfoUpdateDto).Url)
                .NotEmpty()
                .When(dto => (dto as ContactInfoUpdateDto).Category == "website")
                .WithMessage("URL is required for website category")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Invalid URL format");

            RuleFor(dto => (dto as ContactInfoUpdateDto).Email)
                .EmailAddress()
                .WithMessage("Invalid email format");

        });
    }
}
}
