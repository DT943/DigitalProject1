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
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookingEngine.Application.AirPortAppService
{
    public class AirPortAppService : BaseAppService<BookingEngineDbContext, Domain.Models.AirPort, AirPortGetDto, AirPortGetDto, AirPortCreateDto, AirPortUpdateDto, SieveModel>, IAirPortAppService
    {
        //private readonly ILanguageAppService _languageAppService;
        private readonly ILanguageApiClient _languageApiClient;

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
            }

        
        public override async Task<AirPortGetDto> Create(AirPortCreateDto create)
        {
            // Get active language codes from Language Service
            //var activeLanguageCodes = await _languageApiClient.GetActiveLanguageCodesAsync();

            //var providedLangCodes = create.AirPortTranslations.Select(x => x.LanguageCode).ToList();
            //var missingLangs = activeLanguageCodes.Except(providedLangCodes).ToList();

            //if (missingLangs.Any())
            //{
             //   throw new ValidationException($"Missing translations for languages: {string.Join(", ", missingLangs)}");
            //}

            return await base.Create(create);
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
        protected override IQueryable<Domain.Models.AirPort> QueryExcuter(SieveModel input)
        {
            var languageFilter = input?.Filters?
                .Split(';', StringSplitOptions.RemoveEmptyEntries)
                .FirstOrDefault(f => f.StartsWith("language=="));

            string languageCode = null;
            if (languageFilter != null)
            {
                languageCode = languageFilter.Split("==")[1];

                input.Filters = string.Join(";", input.Filters
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .Where(f => !f.StartsWith("language==")));
            }

            IQueryable<Domain.Models.AirPort> query = base.QueryExcuter(input)
                .Include(x => x.AirPortTranslations);

            if (!string.IsNullOrEmpty(languageCode))
            {
                // First filter by translation existence
                query = query.Where(a => a.AirPortTranslations.Any(t => t.LanguageCode == languageCode));

                // Then use Select to trim the AirPortTranslations list to only the matching one
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

            return query;
            //return base.QueryExcuter(input)
            //  .Include(x => x.AirPortTranslations);
        }
    }

}
