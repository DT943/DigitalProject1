using Gallery.Application.GalleryAppService;
using Hotel.Application.HotelAppService;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.HotelGalleryAppService.Dtos;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Hotel.Host.Controllers
{
    [Authorize]
    public class HotelController : BaseController<IHotelAppService, Domain.Models.Hotel, HotelGetDto, HotelGetDto, HotelCreateDto, HotelUpdateDto, SieveModel>
    {
        IHotelAppService _hotelAppService;
        IGalleryAppService _galleryAppService;
        public HotelController(IHotelAppService hotelAppService, IGalleryAppService galleryAppService) : base(hotelAppService)
        {
            _hotelAppService = hotelAppService;
            _galleryAppService = galleryAppService;
        }

        public override async Task<ActionResult<HotelGetDto>> Create(HotelCreateDto dto)
        {

            var galleries = new List<HotelGalleryCreateDto>();

            string[] gallieryType = ["gym", "lobby"];
            foreach (var item in gallieryType)
            {
               var gymGallery = await _galleryAppService.Create
                          (
                            new Gallery.Application.GalleryAppService.Dtos.GalleryCreateDto
                            {
                                Name = dto.Name.ToLower() + "-" + item,
                                Type = "hotel",
                                Description = dto.Name.ToLower() + "-" + item
                            }
                          );
                galleries.Add(new HotelGalleryCreateDto { GalleryCode = gymGallery.Code, GalleryName = gymGallery.Name, GalleryType = "hotel" });

            }

            dto.HotelGallery = galleries;
            return await base.Create(dto);
        }


    }
}
