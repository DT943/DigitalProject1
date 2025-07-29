using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.AirPortAppService.Dtos;
using BookingEngine.Application.AirPortAppService.Validations;
using BookingEngine.Application.ExternalService;
using BookingEngine.Data.DbContext;
using BookingEngine.Domain.Models;
using CWCore.Application.LanguageAppService;
using Infrastructure.Application;
using Infrastructure.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Infrastructure.Application.BasicDto;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookingEngine.Application.AirPortAppService
{
    public class AirPortAppService : BaseAppService<BookingEngineDbContext, Domain.Models.AirPort, AirPortGetDto, AirPortGetDto, AirPortCreateDto, AirPortUpdateDto, SieveModel>, IAirPortAppService
    {
        //private readonly ILanguageAppService _languageAppService;
        private readonly ILanguageApiClient _languageApiClient;
        BookingEngineDbContext _serviceDbContext;
        public AirPortAppService(
            BookingEngineDbContext serviceDbContext,
            IMapper mapper,
            ISieveProcessor processor,
            AirPortValidator validations,
            IHttpContextAccessor httpContextAccessor,
            ILanguageApiClient languageApiClient)
            : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
            {
                _languageApiClient = languageApiClient;
                _serviceDbContext = serviceDbContext;

            }
        public override async Task<PaginatedResult<AirPortGetDto>> GetAll(SieveModel input)
        {
            // Step 1: Extract custom filters
            var filters = input?.Filters?
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .ToList() ?? new List<string>();

            string languageCode = null;
            string searchTerm = null;

            // Extract language filter
            var languageFilter = filters.FirstOrDefault(f => f.StartsWith("language==", StringComparison.OrdinalIgnoreCase));
            if (languageFilter != null)
            {
                languageCode = languageFilter.Split("==")[1].Trim();
                filters.Remove(languageFilter);
            }

            // Extract smart search filter
            var searchFilter = filters.FirstOrDefault(f => f.StartsWith("search@=", StringComparison.OrdinalIgnoreCase));
            if (searchFilter != null)
            {
                searchTerm = searchFilter.Split(new[] { "search@=" }, StringSplitOptions.None)[1].Trim().ToLower();
                filters.Remove(searchFilter);
            }

            // Put remaining filters back for Sieve to process
            input.Filters = string.Join(";", filters);

            // Step 2: Start query with includes
            IQueryable<Domain.Models.AirPort> query = base.QueryExcuter(input)
                .Include(x => x.AirPortTranslations);

            // Step 3: Apply language and smart search filters
            if (!string.IsNullOrEmpty(languageCode))
            {
                query = query.Where(a => a.AirPortTranslations.Any(t => t.LanguageCode == languageCode));

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(a =>
                        
                        a.IATACode.ToLower().Contains(searchTerm) ||
                        a.AirPortTranslations.Any(t =>
                            t.LanguageCode == languageCode &&
                            (
                                t.City.ToLower().Contains(searchTerm) ||
                                t.Country.ToLower().Contains(searchTerm) ||
                                t.AirPortName.ToLower().Contains(searchTerm)
                            )));
                }

                // Project translations to only the matched language
                query = query.Select(a => new Domain.Models.AirPort
                {
                    Id = a.Id,
                    IATACode = a.IATACode,
                    Code = a.Code,
                    CreatedBy = a.CreatedBy,
                    CreatedDate = a.CreatedDate,
                    ModifiedBy = a.ModifiedBy,
                    ModifiedDate = a.ModifiedDate,
                    IsDeleted = a.IsDeleted,
                    AirPortTranslations = a.AirPortTranslations
                        .Where(t => t.LanguageCode == languageCode)
                        .ToList()
                });
            }
            else if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(a =>
                    
                    a.IATACode.ToLower().Contains(searchTerm) ||
                    a.AirPortTranslations.Any(t =>
                        t.City.ToLower().Contains(searchTerm) ||
                        t.Country.ToLower().Contains(searchTerm) ||
                        t.AirPortName.ToLower().Contains(searchTerm)));
            }

            // Step 4: Execute and apply pagination via Sieve
            var resultList = await query.AsNoTracking().ToListAsync();
            var filteredForCount = _processor.Apply(input, resultList.AsQueryable(), applyPagination: false);
            var filtered = _processor.Apply(input, filteredForCount);
            var count = filteredForCount.Count();

            return new PaginatedResult<AirPortGetDto>
            {
                Items = _mapper.Map<List<AirPortGetDto>>(filtered),
                TotalCount = count,
                Page = input.Page ?? 1,
                PageSize = input.PageSize ?? count
            };
        }

        public async Task<PaginatedResult<AirPortGetDto>> GetSpecific(SieveModel input, string from)
        {
            IQueryable<Domain.Models.AirPort> query;

            if (from == "DAM" || from == "ALP")
            {
                query = base.QueryExcuter(input)
                     .Include(x => x.AirPortTranslations).Where(x=> x.IATACode != "DAM" &&  x.IATACode != "ALP");

            }
            else
            {
               query = base.QueryExcuter(input)
             .Include(x => x.AirPortTranslations).Where(x => x.IATACode == "DAM" || x.IATACode == "ALP");

            }


            // Step 4: Execute and apply pagination via Sieve
            var resultList = await query.AsNoTracking().ToListAsync();
            var filteredForCount = _processor.Apply(input, resultList.AsQueryable(), applyPagination: false);
            var filtered = _processor.Apply(input, filteredForCount);
            var count = filteredForCount.Count();

            return new PaginatedResult<AirPortGetDto>
            {
                Items = _mapper.Map<List<AirPortGetDto>>(filtered),
                TotalCount = count,
                Page = input.Page ?? 1,
                PageSize = input.PageSize ?? count
            };
        }



        public override async Task<AirPortGetDto> Create(AirPortCreateDto create)
        {
            var existing = await _serviceDbContext.AirPorts
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(x => x.IATACode.ToUpper() == create.IATACode.Trim().ToUpper() && !x.IsDeleted);

            if (existing != null)
            {
                var modelState = new ModelStateDictionary();
                modelState.AddModelError("iataCode", "An airport with this IATA code already exists.");

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

            //var providedLangCodes = create.AirPortTranslations.Select(x => x.LanguageCode).ToList();
            //var missingLangs = activeLanguageCodes.Except(providedLangCodes).ToList();

            //if (missingLangs.Any())
            //{
            //   throw new ValidationException($"Missing translations for languages: {string.Join(", ", missingLangs)}");
            //}

        }

        public override async Task<AirPortGetDto> Update(AirPortUpdateDto update)
        {
            // Get active language codes from Language Service
            //var activeLanguageCodes = await _languageApiClient.GetActiveLanguageCodesAsync();

            //var providedLangCodes = update.AirPortTranslations.Select(x => x.LanguageCode).ToList();
            //var missingLangs = activeLanguageCodes.Except(providedLangCodes).ToList();

            //if (missingLangs.Any())
            //{
            //    throw new ValidationException($"Missing translations for languages: {string.Join(", ", missingLangs)}");
            //}

            return await base.Update(update);
        }
        /*
        public override async Task<AirPortGetDto> Get(int id)
        {
            const string languageCode = "en";

            var result = await _serviceDbContext.AirPorts
                .Include(a => a.AirPortTranslations.Where(t => t.LanguageCode == languageCode))
                .FirstOrDefaultAsync(a => a.Id == id);

            if (result == null)
                throw new EntityNotFoundException(nameof(AirPort), id.ToString());

            return _mapper.Map<AirPortGetDto>(result);
        }
        */
        public string GetByIataCode(string iataCode)
        {
            var airport = _serviceDbContext.AirPorts
                .Include(x => x.AirPortTranslations)
                .FirstOrDefault(x => x.IATACode == iataCode);

            var englishTranslation = airport?.AirPortTranslations
                .FirstOrDefault(t => t.LanguageCode == "en");

            return englishTranslation?.AirPortName ?? string.Empty;
        }

        protected override IQueryable<Domain.Models.AirPort> QueryExcuter(SieveModel input)
        {
            
            return base.QueryExcuter(input)
              .Include(x => x.AirPortTranslations);
        }
    }

}
