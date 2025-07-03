using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gallery.Application.GalleryAppService.Dtos;
using Gallery.Application.GalleryAppService.Validations;
using Gallery.Data.DbContext;
using Infrastructure.Application;
using Infrastructure.Application.BasicDto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public override async Task<PaginatedResult<GalleryGetDto>> GetAll(SieveModel input)
        {
            // Get all galleries first
            var allGallery = await base.GetAll(input);

            // Get distinct file types for each gallery in a single query and map them directly
            var fileTypes = await _serviceDbContext.Files
                .Where(file => allGallery.Items.Select(g => g.Id).Contains(file.GalleryId))
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
            foreach (var item in allGallery.Items)
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

        public async Task<GalleryGetDto> GetByName(string name)
        {
            var gallery = await _serviceDbContext.Galleries.Where(x => x.Name.ToLower() == name.ToLower()).ToListAsync();
            return _mapper.Map<GalleryGetDto>(gallery);
        }

        public async Task<List<GalleryGetDto>> GetGalleriesByNames(List<string> names)
        {
            var galleries = await _serviceDbContext.Galleries
                .Where(g => names.Contains(g.Name))
                .ToListAsync();
            return _mapper.Map<List<GalleryGetDto>>(galleries);
        }
        protected  override Domain.Models.Gallery BeforCreate(GalleryCreateDto create)
        {
            return  base.BeforCreate(create);
        }
        public async Task<List<GalleryGetDto>> CreateBatch(List<GalleryCreateDto> galleries)
        {
            var entities = new List<Domain.Models.Gallery>();

            foreach (var gallery in galleries)
            {
                var entity = _mapper.Map<Domain.Models.Gallery>(gallery);
                entity =  BeforCreate(gallery);
                entities.Add(entity);
            }

            await _serviceDbContext.Galleries.AddRangeAsync(entities);
            await _serviceDbContext.SaveChangesAsync();

            return _mapper.Map<List<GalleryGetDto>>(entities);
        }
        public override async Task<GalleryGetDto> Delete(int id)
        {
            var files = await _serviceDbContext.Files
                .Where(x => x.GalleryId == id)
                .ToListAsync();

            var filePaths = files.Select(f => f.Path).Distinct().ToList();

            _serviceDbContext.Files.RemoveRange(files);
            await _serviceDbContext.SaveChangesAsync();

            foreach (var filePath in filePaths)
            {
                if (!await _serviceDbContext.Files.AnyAsync(x => x.Path == filePath))
                {
                    TryDeleteFile(filePath);
                }
            }

            return await base.Delete(id);
        }

        private void TryDeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    throw new ValidationException("Exception while Deleting this file:"+ filePath);

                }
            }
        }

        protected override IQueryable<Domain.Models.Gallery> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
