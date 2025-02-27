
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.FileAppservice.Validations;
using Gallery.Data.DbContext;
using Infrastructure.Application;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
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

        protected override IQueryable<Domain.Models.File> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
