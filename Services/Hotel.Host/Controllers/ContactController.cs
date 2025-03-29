using Hotel.Application.ContractAppService.Dtos;
using Hotel.Application.ContractAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Hotel.Application.ContactInfoAppService;
using Hotel.Application.ContactInfoAppService.Dtos;
using static Infrastructure.Domain.Consts;

namespace Hotel.Host.Controllers
{
    public class ContactController : BaseController<IContactInfoAppService, Domain.Models.ContactInfo, ContactInfoGetDto, ContactInfoGetDto, ContactInfoCreateDto, ContactInfoUpdateDto, SieveModel>
    {
        IContactInfoAppService _contractAppService;
        public ContactController(IContactInfoAppService contractAppService) : base(contractAppService, Servics.HOTEL)
        {
            _contractAppService = contractAppService;
        }
    }
}
