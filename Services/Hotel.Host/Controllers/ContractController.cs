using Hotel.Application.HotelAppService.Dtos;
using Hotel.Application.HotelAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Hotel.Application.ContractAppService;
using Hotel.Application.ContractAppService.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Hotel.Host.Controllers
{
    [Authorize]

    public class ContractController : BaseController<IContractAppService, Domain.Models.Contract, ContractGetDto, ContractGetDto, ContractCreateDto, ContractUpdateDto, SieveModel>
    {
        IContractAppService _contractAppService;
        public ContractController(IContractAppService contractAppService) : base(contractAppService)
        {
            _contractAppService = contractAppService;
        }
    }
}
