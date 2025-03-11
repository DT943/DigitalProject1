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
    public class GalleryAppService : BaseAppService<GalleryDbContext, Domain.Models.Gallery, GalleryGetDto, GalleryCreateDto, GalleryUpdateDto, SieveModel>, IGalleryAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        GalleryDbContext _serviceDbContext;
        public GalleryAppService(GalleryDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, GalleryValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
        }

        protected override IQueryable<Domain.Models.Gallery> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
