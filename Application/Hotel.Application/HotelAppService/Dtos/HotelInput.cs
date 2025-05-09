using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Application.ContactInfoAppService.Dtos;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Hotel.Domain.Models;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Hotel.Application.HotelAppService.Dtos
{
    public class HotelCreateDto : IValidatableDto
    {

        public string Name { get; set; }
        public string POS { get; set; }
        public string Country { get; set; }
        public string Governate { get; set; }
        public string StreetAddress { get; set; }
        public string? LogoUrl { get; set; }
        public string Status { get; set; }

        public int Rank { get; set; }
        public IEnumerable<HotelGalleryCreateDto> HotelGallery { get; set; } = Enumerable.Empty<HotelGalleryCreateDto>();
        public IEnumerable<ContactInfoCreateDto> ContactInfo { get; set; } = Enumerable.Empty<ContactInfoCreateDto>();
        public IEnumerable<RoomCreateDto> Rooms { get; set; } = Enumerable.Empty<RoomCreateDto>();
        public bool HasAirConditioning { get; set; }
        public bool HasBar { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasPool { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasWifi { get; set; }
        public bool HasSPA { get; set; }
        public bool ArePetsAllowed { get; set; }
        public bool HasShuttle { get; set; }
        public bool HasBreakfast { get; set; }
        public bool HasExtraBed { get; set; }
        public int? ExtraBedPrice { get; set; }

        // Payment Info
        public bool Cash { get; set; }
        public bool CreditCard { get; set; }
        public bool DebitCard { get; set; }
        public bool BankTransfer { get; set; }
        public bool PayPal { get; set; }
        public bool MobilePayment { get; set; }
        public bool CryptoCurrency { get; set; }

        public string? AccountName { get; set; }

        public string? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string? SWIFTCode { get; set; }
        public string? IBAN { get; set; }
        public string? AdditionalInfo { get; set; }


    }


    public class HotelUpdateDto : IEntityUpdateDto
    {

        public string Name { get; set; }
        public string POS { get; set; }
        public string Country { get; set; }
        public string Governate { get; set; }
        public string StreetAddress { get; set; }
        public string? LogoUrl { get; set; }
        public string Status { get; set; }

        public int Rank { get; set; }
        public IEnumerable<ContactInfoUpdateDto> ContactInfo { get; set; } = Enumerable.Empty<ContactInfoUpdateDto>();
        public IEnumerable<RoomUpdateDto> Rooms { get; set; } = Enumerable.Empty<RoomUpdateDto>();

        public bool HasAirConditioning { get; set; }
        public bool HasBar { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasPool { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasWifi { get; set; }
        public bool HasSPA { get; set; }
        public bool ArePetsAllowed { get; set; }
        public bool HasShuttle { get; set; }
        public bool HasBreakfast { get; set; }
        public bool HasExtraBed { get; set; }
        public int? ExtraBedPrice { get; set; }

        // Payment Info
        public bool Cash { get; set; }
        public bool CreditCard { get; set; }
        public bool DebitCard { get; set; }
        public bool BankTransfer { get; set; }
        public bool PayPal { get; set; }
        public bool MobilePayment { get; set; }
        public bool CryptoCurrency { get; set; }

        public string? AccountName { get; set; }

        public string? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string? SWIFTCode { get; set; }
        public string? IBAN { get; set; }
        public string? AdditionalInfo { get; set; }
    }



    public class HotelCreateDetailsDto : IValidatableDto
    {

        public string Name { get; set; }
        public string POS { get; set; }
        public string Governate { get; set; }
        public string StreetAddress { get; set; }
        public string Url { get; set; }

        public int Rank { get; set; }
        public IEnumerable<RoomCreateDto> Rooms { get; set; } = Enumerable.Empty<RoomCreateDto>();
        public IEnumerable<HotelGalleryCreateDto> HotelGallery { get; set; } = Enumerable.Empty<HotelGalleryCreateDto>();

        public IEnumerable<ContactInfoCreateDto> ContactInfo { get; set; } = Enumerable.Empty<ContactInfoCreateDto>();
        public bool HasAirConditioning { get; set; }
        public bool HasBar { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasPool { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasWifi { get; set; }
        public bool HasSPA { get; set; }
        public bool ArePetsAllowed { get; set; }
        public bool Cash { get; set; }
        public bool CreditCard { get; set; }
        public bool DebitCard { get; set; }
        public bool BankTransfer { get; set; }
        public bool PayPal { get; set; }
        public bool MobilePayment { get; set; }
        public bool CryptoCurrency { get; set; }

        public string? AccountName { get; set; }

        public string? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string? SWIFTCode { get; set; }
        public string? IBAN { get; set; }
        public string? AdditionalInfo { get; set; }

    }

}