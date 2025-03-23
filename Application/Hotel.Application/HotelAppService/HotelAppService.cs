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
namespace Hotel.Application.HotelAppService
{
    public class HotelAppService : BaseAppService<HotelDbContext, Domain.Models.Hotel, HotelGetDto, HotelGetDto, HotelCreateDto, HotelUpdateDto, SieveModel>, IHotelAppService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HotelDbContext _serviceDbContext;
        private readonly IMapper _mapper;
        private readonly IGalleryAppService _galleryAppService;

        public HotelAppService(
            HotelDbContext serviceDbContext,
            IMapper mapper,
            ISieveProcessor processor,
            HotelValidator validations,
            IGalleryAppService galleryAppService,
            IHttpContextAccessor httpContextAccessor)
            : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
            _mapper = mapper;
            _galleryAppService = galleryAppService;
        }

        public override async Task<HotelGetDto> Create(HotelCreateDto create)
        {
            var validationResult = await _validations.ValidateAsync(create, options => options.IncludeRuleSets("create", "default"));
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            var galleries = new List<HotelGalleryCreateDto>();

            string[] gallieryType = ["gym", "lobby"];
            foreach (var item in gallieryType)
            {
                var gymGallery = await _galleryAppService.Create
                           (
                             new Gallery.Application.GalleryAppService.Dtos.GalleryCreateDto
                             {
                                 Name = create.Name.ToLower() + "-" + item,
                                 Type = "hotel",
                                 Description = create.Name.ToLower() + "-" + item
                             }
                           );
                galleries.Add(new HotelGalleryCreateDto { GalleryCode = gymGallery.Code, GalleryName = gymGallery.Name, GalleryType = "hotel" });

            }

            create.HotelGallery = galleries;
            return await base.Create(create);
        }

        protected override IQueryable<Domain.Models.Hotel> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input).Include(x=>x.HotelGallery).Include(x=>x.ContactInfo);
        }
    }
}