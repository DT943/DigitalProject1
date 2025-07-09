using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.POSAppService.Dtos;
using BookingEngine.Application.POSAppService.Validations;
using BookingEngine.Application.POSAppService;
using BookingEngine.Application.ExternalService;
using BookingEngine.Data.DbContext;
using Infrastructure.Application.Exceptions;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using Infrastructure.Application.BasicDto;

namespace BookingEngine.Application.POSAppService
{
    public class POSAppService : BaseAppService<BookingEngineDbContext, Domain.Models.POS, POSGetDto, POSGetDto, POSCreateDto, POSUpdateDto, SieveModel>, IPOSAppService
    {
        //private readonly ILanguageAppService _languageAppService;
        private readonly ILanguageApiClient _languageApiClient;
        BookingEngineDbContext _serviceDbContext;
        public POSAppService(
            BookingEngineDbContext serviceDbContext,
            IMapper mapper,
            ISieveProcessor processor,
            POSValidator validations,
            IHttpContextAccessor httpContextAccessor,
            ILanguageApiClient languageApiClient)
            : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _languageApiClient = languageApiClient;
            _serviceDbContext = serviceDbContext;

        }
        public override async Task<PaginatedResult<POSGetDto>> GetAll(SieveModel input)
        {
            // Step 1: Extract custom filters
            var filters = input?.Filters?
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToList() ?? new List<string>();

            string languageCode = null;

            // Extract language filter
            var languageFilter = filters.FirstOrDefault(f => f.StartsWith("language==", StringComparison.OrdinalIgnoreCase));
            if (languageFilter != null)
            {
                languageCode = languageFilter.Split("==")[1].Trim();
                filters.Remove(languageFilter);
            }

            // Put remaining filters back for Sieve to process
            input.Filters = string.Join(";", filters);

            // Step 2: Start query with includes
            IQueryable<Domain.Models.POS> query = base.QueryExcuter(input)
                .Include(x => x.POSTranslations);

            // Step 3: Apply language and smart search filters
            if (!string.IsNullOrEmpty(languageCode))
            {
                query = query.Where(a => a.POSTranslations.Any(t => t.LanguageCode == languageCode));


                // Project translations to only the matched language
                query = query.Select(a => new Domain.Models.POS
                {
                    Id = a.Id,
                    POSCode = a.POSCode,
                    Code = a.Code,
                    CreatedBy = a.CreatedBy,
                    CreatedDate = a.CreatedDate,
                    ModifiedBy = a.ModifiedBy,
                    ModifiedDate = a.ModifiedDate,
                    IsDeleted = a.IsDeleted,
                    POSTranslations = a.POSTranslations
                        .Where(t => t.LanguageCode == languageCode)
                        .ToList()
                });
            }

            // Step 4: Execute and apply pagination via Sieve
            var resultList = await query.AsNoTracking().ToListAsync();
            var filteredForCount = _processor.Apply(input, resultList.AsQueryable(), applyPagination: false);
            var filtered = _processor.Apply(input, filteredForCount);
            var count = filteredForCount.Count();

            return new PaginatedResult<POSGetDto>
            {
                Items = _mapper.Map<List<POSGetDto>>(filtered),
                TotalCount = count,
                Page = input.Page ?? 1,
                PageSize = input.PageSize ?? count
            };
        }


        public override async Task<POSGetDto> Create(POSCreateDto create)
        {
            var existing = await _serviceDbContext.POSs
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(x => x.POSCode.ToUpper() == create.POSCode.Trim().ToUpper() && !x.IsDeleted);

            if (existing != null)
            {
                var modelState = new ModelStateDictionary();
                modelState.AddModelError("posCode", "An POS with this POS code already exists.");

                var problemDetails = new ValidationProblemDetails(modelState)
                {
                    Status = 400,
                    Title = "One or more validation errors occurred.",
                    Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1"
                };

                throw new CustomValidationException(problemDetails);
            }


            return await base.Create(create);
            // Get active language codes from Language Service
            //var activeLanguageCodes = await _languageApiClient.GetActiveLanguageCodesAsync();

            //var providedLangCodes = create.POSTranslations.Select(x => x.LanguageCode).ToList();
            //var missingLangs = activeLanguageCodes.Except(providedLangCodes).ToList();

            //if (missingLangs.Any())
            //{
            //   throw new ValidationException($"Missing translations for languages: {string.Join(", ", missingLangs)}");
            //}

        }

        public override async Task<POSGetDto> Update(POSUpdateDto update)
        {
            // Get active language codes from Language Service
            //var activeLanguageCodes = await _languageApiClient.GetActiveLanguageCodesAsync();

            //var providedLangCodes = update.POSTranslations.Select(x => x.LanguageCode).ToList();
            //var missingLangs = activeLanguageCodes.Except(providedLangCodes).ToList();

            //if (missingLangs.Any())
            //{
            //    throw new ValidationException($"Missing translations for languages: {string.Join(", ", missingLangs)}");
            //}

            return await base.Update(update);
        }
        /*
        public override async Task<POSGetDto> Get(int id)
        {
            const string languageCode = "en";

            var result = await _serviceDbContext.POSs
                .Include(a => a.POSTranslations.Where(t => t.LanguageCode == languageCode))
                .FirstOrDefaultAsync(a => a.Id == id);

            if (result == null)
                throw new EntityNotFoundException(nameof(POS), id.ToString());

            return _mapper.Map<POSGetDto>(result);
        }
        */
        protected override IQueryable<Domain.Models.POS> QueryExcuter(SieveModel input)
        {

            return base.QueryExcuter(input)
              .Include(x => x.POSTranslations);
        }
    }
}
