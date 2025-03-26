using Infrastructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Models
{
    public class Hotel : BasicEntityWithAuditInfo
    {
        public string Name { get; set; }
        public string POS { get; set; }
        public string? Country { get; set; }

        public string? LogoUrl {  get; set; }
        public string Governate { get; set; }
        public string StreetAddress { get; set; }
        public string Url { get; set; }
        public int Rank { get; set; }
        public ICollection<Contract> Contracts { get; set; }

        public ICollection<Room> Rooms { get; set; } 
        public ICollection<HotelGallery> HotelGallery { get; set; }
        // validation 10 
        public ICollection<ContactInfo> ContactInfo { get; set; }

        public string? CommercialDealsFileUrlPath  { get; set; }
        public string? CommercialDealsFileCode { get; set; }

        public bool HasAirConditioning { get; set; }
        public bool HasBar { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasPool { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasWifi { get; set; }
        public bool HasSPA { get; set; }
        public bool ArePetsAllowed { get; set; }


        // Payment Details
        public bool Cash {  get; set; }
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
