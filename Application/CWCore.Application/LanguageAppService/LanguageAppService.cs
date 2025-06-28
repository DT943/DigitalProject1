using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CWCore.Application.POSAppService.Dtos;
using CWCore.Application.POSAppService.Validations;
using CWCore.Application.POSAppService;
using CWCore.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using CWCore.Application.LanguageAppService.Dtos;
using CWCore.Application.LanguageAppService.Validations;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;

namespace CWCore.Application.LanguageAppService
{
    public class LanguageAppService : BaseAppService<CWDbContext, Domain.Models.Language, LanguageGetDto, LanguageGetDto, LanguageCreateDto, LanguageUpdateDto, SieveModel>, ILanguageAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        CWDbContext _serviceDbContext;
        IMapper _mapper;
        public LanguageAppService(CWDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, LanguageValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
            _mapper = mapper;
        }
        public async  Task<List<string>> GetActiveLanguageCodesAsync()
        {
            return await _serviceDbContext.Languages
                .Where(l => l.IsActive)
                .Select(l => l.Code)
                .ToListAsync();
        }

        protected override IQueryable<Domain.Models.Language> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
