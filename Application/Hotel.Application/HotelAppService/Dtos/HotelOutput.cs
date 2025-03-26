using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Application.ContactInfoAppService.Dtos;
using Hotel.Application.ContractAppService.Dtos;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Hotel.Application.RoomAppService.Dtos;
using Hotel.Domain.Models;
using Infrastructure.Application.BasicDto;

namespace Hotel.Application.HotelAppService.Dtos
{
    public class HotelGetDto
    {
        public int Id { get; set; }
        public string Code {  get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string POS { get; set; }
        public string Governate { get; set; }
        public string Url { get; set; }
        public string? LogoUrl { get; set; }
        public IEnumerable<RoomOutputDto>? Rooms { get; set; } = Enumerable.Empty<RoomOutputDto>();
        public IEnumerable<HotelGalleryOutputDto>? HotelGallery { get; set; } = Enumerable.Empty<HotelGalleryOutputDto>();
        public IEnumerable<ContactInfoGetDto> ContactInfo { get; set; } = Enumerable.Empty<ContactInfoGetDto>();
        public IEnumerable<ContractGetDto> Contracts { get; set; } = Enumerable.Empty<ContractGetDto>();

        public string StreetAddress { get; set; }
        public int Rank { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasBar { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasPool { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasWifi { get; set; }
        public bool HasSPA { get; set; }
        public bool ArePetsAllowed { get; set; }

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

    public class HotelGetAllDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string POS { get; set; }
        public string Governate { get; set; }
        public string Url { get; set; }
        public string? LogoUrl { get; set; }
        public string StreetAddress { get; set; }
        public int Rank { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasBar { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasPool { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasWifi { get; set; }
        public bool HasSPA { get; set; }
        public bool ArePetsAllowed { get; set; }

    }
    public class HotelGetDetailsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? POS { get; set; }
        public string? Url { get; set; }
        public string? LogoUrl { get; set; }
        public string? Governate { get; set; }
        public string? StreetAddress { get; set; }

        public int? Rank { get; set; }
        public IEnumerable<RoomOutputDto>? Rooms { get; set; } = Enumerable.Empty<RoomOutputDto>();
        public IEnumerable<HotelGalleryDetailsOutputDto>? HotelGallery { get; set; } = Enumerable.Empty<HotelGalleryDetailsOutputDto>();
        public IEnumerable<ContactInfoGetDto> ContactInfo { get; set; } = Enumerable.Empty<ContactInfoGetDto>();
        public bool HasAirConditioning { get; set; }
        public bool HasBar { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasPool { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasWifi { get; set; }
        public bool HasSPA { get; set; }
        public bool ArePetsAllowed { get; set; }

    }


}
