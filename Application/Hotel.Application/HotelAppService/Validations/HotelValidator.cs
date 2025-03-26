using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FluentValidation;
using Gallery.Data.DbContext;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Hotel.Data.DbContext;
using Infrastructure.Application.Validations;

namespace Hotel.Application.HotelAppService.Validations
{
    public class HotelValidator : AbstractValidator<IValidatableDto>
    {
        HotelDbContext _hotelRepository;
        private static readonly string[] AllowedCategory = { "single", "double" };

        public HotelValidator(HotelDbContext hotelRepository)
        {
            _hotelRepository = hotelRepository;


            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as HotelCreateDto).Name)
                    .NotEmpty()
                    .WithMessage("Hotel name cannot be empty.")
                    .Must(name => name == name.ToLower())
                    .WithMessage("Hotel name must be in lowercase.")
                    .Must((dto, name) => IsUniqueHotelyName(name))
                    .WithMessage("Hotel name must be unique");


                RuleFor(dto => (dto as HotelCreateDto).POS)
                    .NotEmpty()
                    .WithMessage("POS cannot be empty.")
                    .Must(pos => pos == pos.ToLower())
                    .WithMessage("Hotel pos must be in lowercase.");

                RuleFor(dto => (dto as HotelCreateDto).Governate)
                    .NotEmpty()
                    .WithMessage("Governate cannot be empty.")
                    .Must(governate => governate == governate.ToLower())
                    .WithMessage("Hotel governate must be in lowercase.");

                RuleFor(dto => (dto as HotelCreateDto).StreetAddress)
                    .NotEmpty()
                    .WithMessage("Street address cannot be empty.")
                    .Must(streetAddress => streetAddress == streetAddress.ToLower())
                    .WithMessage("Hotel streetAddress must be in lowercase.");

                RuleFor(dto => (dto as HotelCreateDto).Rank)
                    .InclusiveBetween(1, 5)
                    .WithMessage("Rank must be between 1 and 5.");

                RuleForEach(dto => (dto as HotelCreateDto).ContactInfo).ChildRules(contact =>
                {
                     contact.RuleFor(c => c.ContactType).NotEmpty().WithMessage("Contact Type is required");
                     contact.RuleFor(c => c.Category).NotEmpty().WithMessage("Category is required")
                                                        .Must(type => type == "website" || type == "contact")
                                                        .WithMessage("Category must be either 'website' or 'contact'");

                });

                RuleForEach(dto => (dto as HotelCreateDto).Rooms).ChildRules(room =>
                {

                    room.RuleFor(dto => (dto as RoomCreateDto).NumberOfAdults)
                     .Must(d => d >= 0)
                    .WithMessage("Number of adults is not correct.");

                    room.RuleFor(dto => (dto as RoomCreateDto).NumberOfChildren)
                        .Must(d => d >= 0)
                        .WithMessage("Number of children is not correct.");

                    room.RuleFor(dto => (dto as RoomCreateDto).Category)
                         .Must(type => AllowedCategory.Contains(type))
                         .WithMessage($"Category must be one of the following: {string.Join(", ", AllowedCategory)}.")
                         .Must(type => type == type.ToLower())
                        .WithMessage("The Category must be in lowercase.");

                });

                RuleForEach(dto => (dto as HotelCreateDto).ContactInfo)
                    .NotNull()
                    .WithMessage("ContactInfo cannot be null.")
                    .Must(contact => contact.PhoneNumber != null && contact.PhoneNumber.Length >= 10)
                    .WithMessage("Phone number must be leass than 10 characters long.")
                    .Must(contact => contact.Email != null && contact.PhoneNumber.Length >= 10)
                    .WithMessage("Phone number must be leass than 10 characters long.")
                    .Must(contact => contact.PhoneNumber != null && contact.PhoneNumber.All(char.IsDigit))
                    .WithMessage("Phone number must only contain digits.");

                RuleFor(dto => (dto as HotelCreateDto).HasAirConditioning)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has air conditioning.");

                RuleFor(dto => (dto as HotelCreateDto).HasBar)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has a bar.");

                RuleFor(dto => (dto as HotelCreateDto).HasGym)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has a gym.");

                RuleFor(dto => (dto as HotelCreateDto).HasParking)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has parking.");

                RuleFor(dto => (dto as HotelCreateDto).HasPool)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has a pool.");

                RuleFor(dto => (dto as HotelCreateDto).HasRestaurant)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has a restaurant.");

                RuleFor(dto => (dto as HotelCreateDto).HasWifi)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has Wifi.");

                RuleFor(dto => (dto as HotelCreateDto).HasSPA)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has a SPA.");

                RuleFor(dto => (dto as HotelCreateDto).ArePetsAllowed)
                    .NotNull()
                    .WithMessage("Please specify if pets are allowed.");

            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as HotelUpdateDto).Name)
                    .NotEmpty()
                    .WithMessage("Hotel name cannot be empty.")
                    .Must(name => name == name.ToLower())
                    .WithMessage("Hotel name must be in lowercase.");

                RuleFor(dto => (dto as HotelUpdateDto).POS)
                    .NotEmpty()
                    .WithMessage("POS cannot be empty.")
                    .Must(pos => pos == pos.ToLower())
                    .WithMessage("Hotel pos must be in lowercase.");

                RuleFor(dto => (dto as HotelUpdateDto).Governate)
                    .NotEmpty()
                    .WithMessage("Governate cannot be empty.")
                    .Must(governate => governate == governate.ToLower())
                    .WithMessage("Hotel governate must be in lowercase.");

                RuleFor(dto => (dto as HotelUpdateDto).StreetAddress)
                    .NotEmpty()
                    .WithMessage("Street address cannot be empty.")
                    .Must(streetAddress => streetAddress == streetAddress.ToLower())
                    .WithMessage("Hotel streetAddress must be in lowercase.");

                RuleFor(dto => (dto as HotelUpdateDto).Rank)
                    .InclusiveBetween(1, 5)
                    .WithMessage("Rank must be between 1 and 5.");


                RuleForEach(dto => (dto as HotelUpdateDto).ContactInfo)
                    .NotNull()
                    .WithMessage("ContactInfo cannot be null.")
                    .Must(contact => contact.PhoneNumber != null && contact.PhoneNumber.Length >= 10)
                    .WithMessage("Phone number must be leass than 10 characters long.")
                    .Must(contact => contact.Email != null && contact.PhoneNumber.Length >= 10)
                    .WithMessage("Phone number must be leass than 10 characters long.")
                    .Must(contact => contact.PhoneNumber != null && contact.PhoneNumber.All(char.IsDigit))
                    .WithMessage("Phone number must only contain digits.")

                    .Must(contact => contact.Email != null && contact.Email.Length <= 100 && IsValidEmail(contact.Email))
                    .WithMessage("Email must be valid and not exceed 100 characters.");
                RuleForEach(dto => (dto as HotelUpdateDto).Rooms).ChildRules(room =>
                {

                    room.RuleFor(dto => (dto as RoomUpdateDto).NumberOfAdults)
                     .Must(d => d >= 0)
                    .WithMessage("Number of adults is not correct.");

                    room.RuleFor(dto => (dto as RoomUpdateDto).NumberOfChildren)
                        .Must(d => d >= 0)
                        .WithMessage("Number of children is not correct.");

                    room.RuleFor(dto => (dto as RoomUpdateDto).Category)
                         .Must(type => AllowedCategory.Contains(type))
                         .WithMessage($"Category must be one of the following: {string.Join(", ", AllowedCategory)}.")
                         .Must(type => type == type.ToLower())
                        .WithMessage("The Category must be in lowercase.");

                });
                RuleFor(dto => (dto as HotelUpdateDto).HasAirConditioning)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has air conditioning.");

                RuleFor(dto => (dto as HotelUpdateDto).HasBar)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has a bar.");

                RuleFor(dto => (dto as HotelUpdateDto).HasGym)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has a gym.");

                RuleFor(dto => (dto as HotelUpdateDto).HasParking)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has parking.");

                RuleFor(dto => (dto as HotelUpdateDto).HasPool)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has a pool.");

                RuleFor(dto => (dto as HotelUpdateDto).HasRestaurant)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has a restaurant.");

                RuleFor(dto => (dto as HotelUpdateDto).HasWifi)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has Wifi.");

                RuleFor(dto => (dto as HotelUpdateDto).HasSPA)
                    .NotNull()
                    .WithMessage("Please specify if the hotel has a SPA.");

                RuleFor(dto => (dto as HotelUpdateDto).ArePetsAllowed)
                    .NotNull()
                    .WithMessage("Please specify if pets are allowed.");

            });
        }
        // Helper method to check if the email is in a valid format
        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool IsUniqueHotelyName(string name, int? excludeId = null)
        {
            // Convert the name to lowercase and compare
            var galleryExists = _hotelRepository.Hotels
                .Where(g => g.Name.ToLower() == name.ToLower() &&
                            (excludeId == null || g.Id != excludeId))
                .Any();
            return !galleryExists;
        }
    }
}


