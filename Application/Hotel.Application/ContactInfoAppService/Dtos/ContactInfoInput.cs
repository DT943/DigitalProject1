﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Hotel.Application.ContactInfoAppService.Dtos
{
    public class ContactInfoCreateDto : IValidatableDto
    {
        public int HotelId { get; set; }
        public string Category { get; set; }
        public string ContactType { get; set; }
        public bool IsPrimary { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Url { get; set; }
        public string? ResponsiblePerson { get; set; }
        public string? ResponsiblePersonRole { get; set; }
        public string? DisplayLabel { get; set; }


    }
    public class ContactInfoUpdateDto : IEntityUpdateDto
    {
        public int HotelId { get; set; }
        public string Category { get; set; }
        public string ContactType { get; set; }
        public bool IsPrimary { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Url { get; set; }
        public string? ResponsiblePerson { get; set; }
        public string? ResponsiblePersonRole { get; set; }
        public string? DisplayLabel { get; set; }

    }




}
