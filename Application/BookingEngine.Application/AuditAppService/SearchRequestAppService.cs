using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.AuditAppService.Dtos;
using BookingEngine.Application.AuditAppService.Validations;
using BookingEngine.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;

namespace BookingEngine.Application.AuditAppService
{
    public class SearchRequestAppService : BaseAppService<BookingEngineDbContext, Domain.Models.SearchRequest, SearchRequestGetDto, SearchRequestGetDto, SearchRequestCreateDto, SearchRequestUpdateDto, SieveModel>, ISearchRequestAppService
    {
        public SearchRequestAppService(BookingEngineDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, SearchRequestValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
        protected override IQueryable<Domain.Models.SearchRequest> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
