using HR.Application.JobPostAppService.Dtos;
using HR.Application.JobPostAppService;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using HR.Application.CandidateAppService;
using HR.Application.CandidateAppService.Dtos;

namespace HR.Host.Controllers
{
    public class CandidateController : BaseController<ICandidateAppService, Domain.Models.Candidate, CandidateGetAllDto, CandidateGetDto, CandidateCreateDto, CandidateUpdateDto, SieveModel>
    {
        public CandidateController(ICandidateAppService appService) : base(appService, Servics.HR)
        {
        }
    }
}
