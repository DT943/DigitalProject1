using AutoMapper;
using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.HotelAppService.Validations;
using Hotel.Application.HotelAppService;
using Hotel.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Microsoft.EntityFrameworkCore;
using Gallery.Application.GalleryAppService;
using Hotel.Application.HotelGalleryAppService.Dtos;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Gallery.Application.FileAppservice;
using Gallery.Domain.Models;
using Hotel.Domain.Models;
using Gallery.Application.GalleryAppService.Dtos;
namespace Hotel.Application.HotelAppService
{
    public class HotelAppService : BaseAppService<HotelDbContext, Domain.Models.Hotel, HotelGetDto, HotelGetDto, HotelCreateDto, HotelUpdateDto, SieveModel>, IHotelAppService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HotelDbContext _serviceDbContext;
        private readonly IMapper _mapper;
        private readonly IGalleryAppService _galleryAppService;
        private readonly IFileAppService _fileAppService;


        public HotelAppService(
            HotelDbContext serviceDbContext,
            IMapper mapper,
            ISieveProcessor processor,
            HotelValidator validations,
            IGalleryAppService galleryAppService,
            IFileAppService fileAppService,
            IHttpContextAccessor httpContextAccessor)
            : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
            _mapper = mapper;
            _galleryAppService = galleryAppService;
            _fileAppService = fileAppService;
        }

        public override async Task<HotelGetDto> Create(HotelCreateDto create)
        {
            var validationResult = await _validations.ValidateAsync(create, options => options.IncludeRuleSets("create", "default"));
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            var galleries = new List<HotelGalleryCreateDto>();

            string[] gallieryType = ["main","bar","gym","parking","spa","resturant","breakfast","swimmingpool","room-single", "room-double"];
            Dictionary<string, GalleryGetDto> galleryDictionary = new Dictionary<string, GalleryGetDto>();

            foreach (var item in gallieryType)
            {
                var createdGallery = await _galleryAppService.Create
                           (
                             new Gallery.Application.GalleryAppService.Dtos.GalleryCreateDto
                             {
                                 Name = create.Name.ToLower() + "." + item,
                                 Type = "hotel",
                                 Description = create.Name.ToLower() + "." + item
                             }
                );

                galleryDictionary[item] = createdGallery;
                galleries.Add(new HotelGalleryCreateDto { GalleryCode = createdGallery.Code, GalleryName = createdGallery.Name, GalleryType = "hotel" });

            }

            foreach (var room in create.Rooms)
            {
                var gallery = galleryDictionary["rooms"];
                room.Image.GalleryCode = gallery.Code;
                room.Image.GalleryId = gallery.Id;
                var img =  await _fileAppService.Create(room.Image);

                room.ImageUrlPath = img.FileUrlPath;

            }

            {
                var main = galleryDictionary["main"];
                create.CommercialDealsFile.GalleryCode = main.Code;
                create.CommercialDealsFile.GalleryId = main.Id;
                var commercialDealsFile = await _fileAppService.Create(create.CommercialDealsFile);
                create.CommercialDealsFileUrlPath = commercialDealsFile.FileUrlPath;

            }

            create.HotelGallery = galleries;
            return await base.Create(create);
        }

        public override async Task<HotelGetDto> Delete(int id)
        {
            var galleries = await _serviceDbContext.HotelGalleries
                .Where(x => x.HotelId == id)
                .ToListAsync();
            foreach(var gallery in galleries)
            {
                var tempGallery = await _galleryAppService.GetByCode(gallery.GalleryCode);
                await _galleryAppService.Delete(tempGallery.Id);
            }

            return await base.Delete(id);
        }


        protected override IQueryable<Domain.Models.Hotel> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input).Include(x=>x.HotelGallery).Include(x=>x.ContactInfo);
        }
    }
}