using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.AuditAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace BookingEngine.Application.AuditAppService
{
    public interface ISearchRequestAppService : IBaseAppService<SearchRequestGetDto, SearchRequestGetDto, SearchRequestCreateDto, SearchRequestUpdateDto, SieveModel>
    {

    }

}
