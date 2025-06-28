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
using CWCore.Application.LanguageAppService;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

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
        

        protected override IQueryable<Domain.Models.AirPort> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input)
                .Include(x => x.AirPortTranslations);
        }
    }

}
