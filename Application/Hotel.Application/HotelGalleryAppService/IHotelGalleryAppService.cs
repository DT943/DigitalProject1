using Hotel.Application.HotelGalleryAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace Hotel.Application.HotelGalleryAppService
{
    public interface IHotelGalleryAppService : IBaseAppService< HotelGalleryOutputDto, HotelGalleryOutputDto, HotelGalleryInputDto, HotelGalleryUpdateDto, SieveModel>
    {
    }
}