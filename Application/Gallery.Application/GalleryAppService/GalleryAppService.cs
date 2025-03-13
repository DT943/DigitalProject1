using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gallery.Application.GalleryAppService.Dtos;
using Gallery.Application.GalleryAppService.Validations;
using Gallery.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Gallery.Application.GalleryAppService
{
    public class GalleryAppService : BaseAppService<GalleryDbContext, Domain.Models.Gallery, GalleryGetDto, GalleryGetDto, GalleryCreateDto, GalleryUpdateDto, SieveModel>, IGalleryAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        GalleryDbContext _serviceDbContext;
        public GalleryAppService(GalleryDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, GalleryValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }

        public override async Task<IEnumerable<GalleryGetDto>> GetAll(SieveModel input)
        {
            // Get all galleries first
            var allGallery = await base.GetAll(input);

            // Get distinct file types for each gallery in a single query and map them directly
            var fileTypes = await _serviceDbContext.Files
                .Where(file => allGallery.Select(g => g.Id).Contains(file.GalleryId))
                .GroupBy(file => file.GalleryId)
                .Select(group => new
                {
                    GalleryId = group.Key,
                    FileTypes = group.Select(file => file.FileType).Distinct().ToList()
                })
                .ToListAsync();

            // Create a dictionary to map galleryId to its file types
            var fileTypesDictionary = fileTypes.ToDictionary(x => x.GalleryId, x => x.FileTypes);

            // Set the file types for each gallery directly from the dictionary
            foreach (var item in allGallery)
            {
                if (fileTypesDictionary.ContainsKey(item.Id))
                {
                    item.FileTypes = fileTypesDictionary[item.Id];
                }
            }

            return allGallery;
        }


        public override async Task<GalleryGetDto> Get(int id)
        {

            var  gallery = await base.Get(id);
            gallery.FileTypes = await _serviceDbContext.Files.Where(x => x.GalleryId == id).Select(g => g.FileType).Distinct().ToListAsync();

            return gallery;
        }


        protected override IQueryable<Domain.Models.Gallery> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
