﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Application.PageAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace CMS.Application.PageAppService
{
    public interface IPageAppService : IBaseAppService<PageGetDto, PageCreateDto, PageUpdateDto, SieveModel>
    {
        public Task<PageGetDto> GetPageBySubUrl(string pos, string lang, string pageUrlName);

        public Task<IEnumerable<string>> GetSubPathsAsync(string pos, string language, string pageUrlName);
    }
}
