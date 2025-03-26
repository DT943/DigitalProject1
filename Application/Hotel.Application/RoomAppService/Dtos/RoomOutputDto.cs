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
        public int NumberOfAdults { get; set; }
        public int Price { get; set; }
        public string? ImageUrlPath { get; set; }
        public string? ImageCode { get; set; }
        public int NumberOfChildren { get; set; }

        public IList<RoomImageGetDto>? RoomImages { get; set; }

    }


    public class RoomImageGetDto : IValidatableDto
    {
        public int RoomId { get; set; }
        public string? ImageUrlPath { get; set; }
        public string? ImageCode { get; set; }
    }
}


