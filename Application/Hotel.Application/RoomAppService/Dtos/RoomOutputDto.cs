namespace Hotel.Application.RoomAppService.Dtos
{
    public class RoomOutputDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Category { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
    }
}


