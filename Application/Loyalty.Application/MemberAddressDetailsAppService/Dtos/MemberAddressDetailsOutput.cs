﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.MemberAddressDetailsAppService.Dtos
{

    public class MemberAddressDetailsGetDto
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string AddressType { get; set; }

        [MaxLength(200)]
        public string Line1 { get; set; }

        [MaxLength(200)]
        public string Line2 { get; set; }

        [MaxLength(200)]
        public string Line3 { get; set; }

        [MaxLength(200)]
        public string Suburb { get; set; }

        [MaxLength(200)]
        public string City { get; set; }

        [MaxLength(500)]
        public string Province { get; set; }

        [MaxLength(500)]
        public string Country { get; set; }

        [MaxLength(500)]
        public string PostalCode { get; set; }

        public bool Contactable { get; set; }

        public bool Mailable { get; set; }

        [MaxLength(200)]
        public string Landmark { get; set; }
    }

    public class MemberAddressDetailsGetAllDto
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string AddressType { get; set; }

        [MaxLength(200)]
        public string Line1 { get; set; }

        [MaxLength(200)]
        public string Line2 { get; set; }

        [MaxLength(200)]
        public string Line3 { get; set; }

        [MaxLength(200)]
        public string Suburb { get; set; }

        [MaxLength(200)]
        public string City { get; set; }

        [MaxLength(500)]
        public string Province { get; set; }

        [MaxLength(500)]
        public string Country { get; set; }

        [MaxLength(500)]
        public string PostalCode { get; set; }

        public bool Contactable { get; set; }

        public bool Mailable { get; set; }

        [MaxLength(200)]
        public string Landmark { get; set; }
    }
}
