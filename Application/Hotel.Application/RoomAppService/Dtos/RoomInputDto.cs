using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gallery.Application.FileAppservice.Dtos;
using Hotel.Domain.Models;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;
using Microsoft.AspNetCore.Http;

namespace Hotel.Application.HotelAppService.Dtos
    {
        public class RoomCreateDto : IValidatableDto
        {
            public int HotelId { get; set; }
            public string Category { get; set; }
            public string RoomTypeName { get; set; }
            public string? Description { get; set; }
            public int NumberOfAdults { get; set; }
            public int? Price { get; set; }
            public int NumberOfChildren { get; set; }
        }

        public class RoomUpdateDto : IEntityUpdateDto
        {
            public int HotelId { get; set; }
            public string Category { get; set; }
            public string RoomTypeName { get; set; }
            public string? Description { get; set; }
            public int NumberOfAdults { get; set; }
            public int? Price { get; set; }
            public int NumberOfChildren { get; set; }

        }
    }


