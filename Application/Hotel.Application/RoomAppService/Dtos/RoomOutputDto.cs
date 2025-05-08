using Hotel.Application.HotelAppService.Dtos;
using Hotel.Domain.Models;
using Infrastructure.Application.Validations;

namespace Hotel.Application.RoomAppService.Dtos
{
    public class RoomOutputDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Category { get; set; }
        public string RoomTypeName { get; set; }
        public string? Description { get; set; }
        public int NumberOfAdults { get; set; }
        public int? Price { get; set; }
        public int NumberOfChildren { get; set; }

    }
}


