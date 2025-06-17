using HR.Application.CandidateAppService.Dtos;
using HR.Application.CandidateAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using HR.Application.CandidateAppService;
using static Infrastructure.Domain.Consts;

namespace HR.Host.Controllers
{
    public class CandidateController : BaseController<ICandidateAppService, Domain.Models.Candidate, CandidateGetAllDto, CandidateGetDto, CandidateCreateDto, CandidateUpdateDto, SieveModel>
    {
        public CandidateController(ICandidateAppService appService) : base(appService, Servics.HR)
        {
        }

    }
}
