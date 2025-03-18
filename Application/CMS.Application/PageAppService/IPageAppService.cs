using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.PageAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;
//test2
namespace CMS.Application.PageAppService
{
    public interface IPageAppService : IBaseAppService<PageGetDto, PageGetDto, PageCreateDto, PageUpdateDto, SieveModel>
    {
        public Task<PageGetDto> GetPageBySubUrl(string pos, string lang, string pageUrlName);

        public Task<IEnumerable<PageGetUrl>> GetSubPathsAsync(string pos, string language, string pageUrlName);

        public Task<IEnumerable<PageGetDto>> GetPageByStatus(string status);
    }
}
