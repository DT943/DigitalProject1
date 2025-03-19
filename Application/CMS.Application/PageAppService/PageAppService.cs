using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.PageAppService.Dtos;
using CMS.Application.PageAppService.Validations;
using CMS.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace CMS.Application.PageAppService
{
    public class PageAppService : BaseAppService<CMSDbContext, Domain.Models.Page, PageGetDto, PageGetDto, PageCreateDto, PageUpdateDto, SieveModel>, IPageAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        CMSDbContext _serviceDbContext;
        IMapper _mapper;
        public PageAppService(CMSDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, PageValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
            _mapper = mapper;
        }

        protected override IQueryable<Domain.Models.Page> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input).Include(x => x.Segments).ThenInclude(x => x.Components);
        }

        public override async Task<PageGetDto> Create(PageCreateDto create)
        {
            create.Status = "draft";

            return await base.Create(create);
        }
        public async Task<PageGetDto> GetPageBySubUrl(string pos, string language, string pageUrlName)
        {
            var result =  _serviceDbContext.Pages.Where(x => x.Language.ToLower().Equals(language.ToLower()) 
            && x.POS.ToLower().Equals(pos.ToLower())
            && x.PageUrlName.ToLower().Equals(pageUrlName.ToLower())).FirstOrDefault();

            
            return await Task.FromResult(_mapper.Map<PageGetDto>(result));
            
        }


        public async Task<IEnumerable<PageGetDto>> GetPageByStatus(string status)
        {
            var result = _serviceDbContext.Pages.Where(x => x.Status.ToLower().Equals(status)).ToList();
            return await Task.FromResult(_mapper.Map<IEnumerable<PageGetDto>>(result));

        }

        public async Task<IEnumerable<PageGetUrl>> GetSubPathsAsync(string pos, string language, string pageUrlName)
        {
            if (string.IsNullOrEmpty(pageUrlName))
            {
                // Get the parent URLs if pageUrlName is not provided
                var parentUrls = _serviceDbContext.Pages
                    .Where(p => p.POS.ToLower().Equals(pos.ToLower()) && p.Language.ToLower().Equals(language.ToLower()))
                    .Select(p => new { p.Id, p.PageUrlName })
                    .ToList();

                var result = parentUrls
                    .Select(p => new PageGetUrl
                    {
                        Id = p.Id,
                        PageUrlName = p.PageUrlName.Split('/')[0] // Get the first part (parent path)
                    })
                    .Distinct()
                    .ToList();

                return result;
            }

            // Get the URLs that start with the given pageUrlName if it's provided
            var urls = await _serviceDbContext.Pages
                .Where(p => p.POS.ToLower().Equals(pos.ToLower()) && p.Language.ToLower().Equals(language.ToLower()) && p.PageUrlName.StartsWith(pageUrlName))
                .Select(p => new { p.Id, p.PageUrlName })
                .ToListAsync();

            var resultWithSubPath = urls
                .Select(p => new PageGetUrl
                {
                    Id = p.Id,
                    PageUrlName = GetNextLevel(pageUrlName, p.PageUrlName) // Get the next level of sub-path
                })
                .Where(p => !string.IsNullOrEmpty(p.PageUrlName)) // Filter out null or empty sub-paths
                .Distinct()
                .ToList();

            return resultWithSubPath;
        }



        private string GetNextLevel(string inputUrl, string fullUrl)
        {
            var inputParts = inputUrl.Split('/');
            var fullParts = fullUrl.Split('/');

            if (fullParts.Length > inputParts.Length)
            {
                return string.Join("/", fullParts.Take(inputParts.Length + 1));
            }

            return null;
        }
    }
}
