using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWCore.Application.POSAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace CWCore.Application.POSAppService
{
    public interface IPOSAppService : IBaseAppService<POSGetDto, POSGetDto, POSCreateDto, POSUpdateDto, SieveModel>
    {
        public Task<ICollection<POSGetDto>> GetByPOSKey(string code);

    }
}
