using Hotel.Application.HotelGalleryAppService.Dtos;
using Hotel.Application.RoomAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace Hotel.Application.HotelGalleryAppService
{
    public interface IHotelGalleryAppService : IBaseAppService< HotelGalleryOutputDto, HotelGalleryOutputDto, HotelGalleryCreateDto, HotelGalleryUpdateDto, SieveModel>
    {
       Task<IEnumerable<HotelGalleryOutputDto>> GetHotelGalleryByHotelIdAsync(int hotelId);
    }
}