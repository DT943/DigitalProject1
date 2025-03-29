using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Application.ContactInfoAppService.Dtos;
using Hotel.Application.ContractAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace Hotel.Application.ContractAppService
{
    public interface IContractAppService : IBaseAppService<ContractGetDto, ContractGetDto, ContractCreateDto, ContractUpdateDto, SieveModel>
    {
    }
}
