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
            string[] galleryTypes = ["main", "bar", "gym", "parking", "spa", "resturant", "breakfast", "swimmingpool", "room-single", "room-double"];

            // Generate all possible gallery names
            var galleryNames = galleryTypes.Select(item => create.Name.ToLower() + "." + item).ToList();

            // Get all existing galleries in one query
            var existingGalleries = await _galleryAppService.GetGalleriesByNames(galleryNames);
            var existingGalleryNames = existingGalleries.Select(g => g.Name).ToHashSet();

            // Prepare galleries to be created
            var galleriesToCreate = galleryNames
                .Where(name => !existingGalleryNames.Contains(name))
                .Select(name => new GalleryCreateDto
                {
                    Name = name,
                    Type = "hotel",
                    Description = name
                })
                .ToList();

                // Batch create new galleries
                var newGalleries = galleriesToCreate.Any()
                    ? await _galleryAppService.CreateBatch(galleriesToCreate)
                    : new List<GalleryGetDto>();
            // Combine existing and new galleries
            var allGalleries = existingGalleries.Concat(newGalleries);

            // Map to HotelGalleryCreateDto
            galleries.AddRange(allGalleries.Select(gallery => new HotelGalleryCreateDto
            {
                GalleryCode = gallery.Code,
                GalleryName = gallery.Name,
                GalleryType = "hotel"
            }));

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