using AutoMapper;
using CWCore.Application.LanguageAppService;
using CWCore.Application.LanguageAppService.Dtos;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace Orchestration.Host.Controllers
{
    public class LanguageController : BaseController<ILanguageAppService, CWCore.Domain.Models.Language, LanguageGetDto, LanguageGetDto, LanguageCreateDto, LanguageUpdateDto, SieveModel>
    {
        ILanguageAppService _languageAppService;
        public LanguageController(ILanguageAppService languageAppService) : base(languageAppService, Servics.CWCORE)
        {
            _languageAppService = languageAppService;
        }

        [HttpGet("ActiveLanguages")]
        public async Task<List<string>> GetActiveLanguageCodes()
        {
            return await _languageAppService.GetActiveLanguageCodesAsync();
        }

    }

}
