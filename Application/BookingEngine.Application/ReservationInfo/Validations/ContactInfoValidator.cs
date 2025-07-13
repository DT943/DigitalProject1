using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PassengerInfo.Dtos;
using BookingEngine.Application.PassengerInfo.Validations;
using BookingEngine.Application.ReservationInfo.Dtos;
using FluentValidation;
using Infrastructure.Application.EmailValidation;
using Infrastructure.Application.PhoneValidation;
using Infrastructure.Application.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookingEngine.Application.ReservationInfo.Validations
{
     public class ContactInfoValidator: AbstractValidator<IValidatableDto>
     {

        public ContactInfoValidator(IConfiguration configuration)
        {
            string _emailValidationApiKey = configuration["EmailValidation:ApiKey"];
            string _phoneValidationApiKey = configuration["PhoneValidation:ApiKey"];


            RuleSet("create", () =>
            {
                When(x => x is ContactInfoCreateDto, () =>
                {

                   RuleFor(x => ((ContactInfoCreateDto)x).PhoneNumber)
                       .NotEmpty().WithMessage("PhoneNumber is required.")
                       .MaximumLength(15)
                       .MustAsync(async (phone, cancellation) =>
                       {
                            var isValid = await PhoneValidation.GetPhoneValidationAsync(_phoneValidationApiKey, phone);
                            return isValid;
                       }).WithMessage("This phone number is not valid.");

                    RuleFor(x => ((ContactInfoCreateDto)x).Email)
                        .NotEmpty()
                        .WithMessage("The Email cannot be empty.")
                        .EmailAddress()
                        .WithMessage("The Email format is invalid.").EmailAddress()
                        .WithMessage("Invalid email format.")
                        .MustAsync(async (email, cancellation) =>
                        {
                            var score = await EmailValidation.GetEmailValidationScore(_emailValidationApiKey, email);

                            return score;

                        }).WithMessage("This email is not valid.");

                   
                   // RuleFor(x => ((ContactInfoCreateDto)x).Passengers)
                     //   .NotEmpty().WithMessage("Passengers list cannot be empty.")
                       // .ForEach(passenger =>
                         //   passenger.SetValidator(new PassengerInfoValidator()));



                });
            });

            RuleSet("update", () =>
            {
                When(x => x is PassengerInfoUpdateDto, () =>
                {

                });
            });


        }
     }
}
