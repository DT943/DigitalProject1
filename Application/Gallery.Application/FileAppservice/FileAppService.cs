
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.FileAppservice.Validations;
using Gallery.Data.DbContext;
using Infrastructure.Application;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Application.Exceptions;
using System.Collections.Generic;
namespace Gallery.Application.FileAppservice
{
    public class FileAppService : BaseAppService<GalleryDbContext, Domain.Models.File, FileGetDto, FileCreateDto, FileUpdateDto, SieveModel>, IFileAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        GalleryDbContext _serviceDbContext;
        public FileAppService(GalleryDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, FileValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }


        public bool CheckPath(string path)
        {
            return _serviceDbContext.Files.Any(f => f.Path.Equals(path));
        }


        public async Task<IEnumerable<FileGetDto>> GetRelatedFileGallery(int GalleryId)
        {
            return _mapper.Map<List<FileGetDto>>( _serviceDbContext.Files.Where(f => f.GalleryId == GalleryId).ToList());
        }

        protected override IQueryable<Domain.Models.File> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }

 
    }
}
