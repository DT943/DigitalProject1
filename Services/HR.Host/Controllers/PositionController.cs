using HR.Application.PositionAppService.Dtos;
using HR.Application.PositionAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace HR.Host.Controllers
{
    public class PositionController : BaseController<IPositionAppService, Domain.Models.Position, PositionGetAllDto, PositionGetDto, PositionCreateDto, PositionUpdateDto, SieveModel>
    {
        public PositionController(IPositionAppService appService) : base(appService, Servics.HR)
        {
        }
    }
    
}
