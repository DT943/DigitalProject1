using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWCore.Application.LanguageAppService.Dtos;
using CWCore.Application.POSAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace CWCore.Application.LanguageAppService
{
    public interface ILanguageAppService : IBaseAppService<LanguageGetDto, LanguageGetDto, LanguageCreateDto, LanguageUpdateDto, SieveModel>
    {
        Task<List<string>> GetActiveLanguageCodesAsync();

    }

}
