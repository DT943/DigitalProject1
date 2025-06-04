using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.TravelAgentEmployeeAppService.Dto;
using B2B.Application.TravelAgentOffice.Dto;
using Infrastructure.Application;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace B2B.Application.TravelAgentOffice
{
    public interface ITravelAgentOfficeAppService : IBaseAppService<TravelAgentOfficeGetAllDto, TravelAgentOfficeGetDto, TravelAgentOfficeCreateDto, TravelAgentOfficeUpdateDto, SieveModel>
    {
        Task<ActionResult<TravelAgentOfficeGetDto>> Approve(TravelAgentProcessApproveDto travelAgentProcessApproveDto);

        Task<ActionResult<TravelAgentOfficeGetDto>> GetTravelAgentOfficeByUserCode();

    }
}
