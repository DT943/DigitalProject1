using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hotel.Domain.Models;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Hotel.Application.HotelAppService.Dtos
    {
        public class RoomCreateDto : IValidatableDto
        {
            public int HotelId { get; set; }
            public string Category { get; set; }
            public int NumberOfAdults { get; set; }
            public int Price { get; set; }

            public int NumberOfChildren { get; set; }


        }

        public class RoomUpdateDto : IEntityUpdateDto
        {
            public string Category { get; set; }
            public int NumberOfAdults { get; set; }
            public int Price { get; set; }

            public int NumberOfChildren { get; set; }

        }
    }


