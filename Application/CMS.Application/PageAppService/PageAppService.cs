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
    public class PageAppService : BaseAppService<CMSDbContext, Domain.Models.Page, PageGetDto, PageCreateDto, PageUpdateDto, SieveModel>, IPageAppService
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

        public async Task<PageGetDto> GetPageBySubUrl(string pos, string language, string pageUrlName)
        {
            var result =  _serviceDbContext.Pages.Where(x => x.Language.ToLower().Equals(language.ToLower()) 
            && x.POS.ToLower().Equals(pos.ToLower())
            && x.PageUrlName.ToLower().Equals(pageUrlName.ToLower())).FirstOrDefault();

            
            return await Task.FromResult(_mapper.Map<PageGetDto>(result));
            
        }


        public async Task<IEnumerable<string>> GetSubPathsAsync(string pos, string language, string pageUrlName)
        {

            if (string.IsNullOrEmpty(pageUrlName))
            {
                var parentUrls = _serviceDbContext.Pages.Where(p => p.POS.ToLower().Equals(pos.ToLower()) && p.Language.ToLower().Equals(language.ToLower()))
                    .Select(p => p.PageUrlName) // Assuming your entity has a `Url` column
                    .ToList();

                return parentUrls
                    .Select(url => url.Split('/')[0])  // Get the first part (parent path)
                    .Distinct()
                    .ToList();
            }

            var urls = await _serviceDbContext.Pages
                .Where(p => p.POS.ToLower().Equals(pos.ToLower()) && p.Language.ToLower().Equals(language.ToLower()) && p.PageUrlName.StartsWith(pageUrlName))
                .Select(p => p.PageUrlName)
                .ToListAsync();

            return urls
                .Select(url => GetNextLevel(pageUrlName, url))
                .Where(url => !string.IsNullOrEmpty(url))
                .Distinct();
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
