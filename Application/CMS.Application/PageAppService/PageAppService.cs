using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Application.PageAppService.Dtos;
using CMS.Application.PageAppService.Validations;
using CMS.Application.StaticComponentAppService;
using CMS.Data.DbContext;
using Infrastructure.Application;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Exceptions;
using Infrastructure.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace CMS.Application.PageAppService
{
    public class PageAppService : BaseAppService<CMSDbContext, Domain.Models.Page, PageGetDto, PageGetDto, PageCreateDto, PageUpdateDto, SieveModel>, IPageAppService
    {
        IStaticComponentAppService _staticComponentAppService;
        IHttpContextAccessor _httpContextAccessor;
        CMSDbContext _serviceDbContext;
        IMapper _mapper;
        public PageAppService(CMSDbContext serviceDbContext, IStaticComponentAppService staticComponentAppService, IMapper mapper, ISieveProcessor processor, PageValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _staticComponentAppService = staticComponentAppService;
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

        public override async Task<PageGetDto> Update(PageUpdateDto update)
        {
            update.Status = "draft";

            return await base.Update(update);
        }


        public async Task<PageGetDto> GetPageBySubUrl(string pos, string language, string pageUrlName)
        {
            var result =  _serviceDbContext.Pages.Where(x => x.Language.ToLower().Equals(language.ToLower()) 
            && x.POS.ToLower().Equals(pos.ToLower())
            && x.PageUrlName.ToLower().Equals(pageUrlName.ToLower())).Include(x => x.Segments).ThenInclude(x=>x.Components).FirstOrDefault();
            var pages = _mapper.Map<PageGetDto>(result);
            if (pages != null)
            {
                var staticComponents = await _staticComponentAppService.GetAll(new SieveModel());
                pages.StaticComponents = (ICollection<StaticComponentAppService.Dto.StaticComponentGetDto>)staticComponents.Items;
            }
            return await Task.FromResult(pages);
            
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
                .Where(p => p.POS.ToLower().Equals(pos.ToLower()) && p.Language.ToLower().Equals(language.ToLower()) && p.PageUrlName.StartsWith(pageUrlName.TrimEnd('/') + "/"))
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

        public async Task<bool> RecursiveDelete(int id)
        {
            var result = await _serviceDbContext.Set<Domain.Models.Page>().FirstOrDefaultAsync(x => x.Id.Equals(id));
            _serviceDbContext.Set<Domain.Models.Page>().Remove(result);

            var sons = await GetSubPathsAsync(result.POS, result.Language, result.PageUrlName);
            foreach (var item in sons)
            {
                await RecursiveDelete(item.Id);
            }

            return true;
        }

        public override async Task<PageGetDto> Delete(int id)
        {
            var result = await _serviceDbContext.Set<Domain.Models.Page>().FirstOrDefaultAsync(x => x.Id.Equals(id));
            await RecursiveDelete(id);
            await _serviceDbContext.SaveChangesAsync();
            return await Task.FromResult(_mapper.Map<PageGetDto>(result));
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


        protected override Domain.Models.Page BeforUpdate(PageUpdateDto update, Domain.Models.Page entity)
        {
            if (entity is BasicEntityWithAuditInfo auditInfo)
            {
                auditInfo.ModifiedBy = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
                auditInfo.ModifiedDate = DateTime.Now;
                if (entity is ApproveEntityWithAudit)
                {
                    (entity as ApproveEntityWithAudit).AwaitingApprovalUserCode = _httpContextAccessor.HttpContext?.User.FindFirst("managerCode")?.Value;
                    (entity as ApproveEntityWithAudit).ApprovalStatus = "PendingApproval";
                }
            }

            // Map top-level props
            var newEntity = _mapper.Map(update, entity);

            // Handle nested collections if Page → Segments → Components
            if (update is PageUpdateDto pageUpdate && entity is Domain.Models.Page pageEntity)
            {
                foreach (var segmentDto in pageUpdate.Segments)
                {
                    var existingSegment = pageEntity.Segments.FirstOrDefault(s => s.Id == segmentDto.Id);
                    if (existingSegment != null)
                    {
                        _mapper.Map(segmentDto, existingSegment); // Code is preserved by config

                        // Now map nested Components
                        foreach (var componentDto in segmentDto.Components)
                        {
                            var existingComponent = existingSegment.Components.FirstOrDefault(c => c.Id == componentDto.Id);
                            if (existingComponent != null)
                            {
                                _mapper.Map(componentDto, existingComponent); // preserves Code
                            }
                            else
                            {
                                var newComponent = _mapper.Map<Domain.Models.Component>(componentDto);
                                existingSegment.Components.Add(newComponent);
                            }
                        }
                    }
                    else
                    {
                        var newSegment = _mapper.Map<Domain.Models.Segment>(segmentDto);
                        pageEntity.Segments.Add(newSegment);
                    }
                }
            }

            return entity;
        }



        public override async Task<ApprovedResult<PageGetDto>> Approve(int id, bool canApprove)
        {
            var approvedPage = await base.Approve(id, canApprove);

            if (approvedPage != null && approvedPage.Item.ApprovalStatus == "Approved")
            {
               var page =  await _serviceDbContext.Pages.FindAsync(id);
                page.Status = "published";

                await _serviceDbContext.SaveChangesAsync();
            }

            return new ApprovedResult<PageGetDto>
            {
                Result = approvedPage.Result,
                Item = await this.Get(id)
            };
        }
    }
}
