using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.RoomAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace Hotel.Application.RoomAppService
{
    public interface IRoomAppService : IBaseAppService<RoomOutputDto, RoomOutputDto, RoomCreateDto, RoomUpdateDto, SieveModel>
    {
        Task<List<RoomOutputDto>> GetRoomsByHotelIdAsync(int hotelId);
    }
}