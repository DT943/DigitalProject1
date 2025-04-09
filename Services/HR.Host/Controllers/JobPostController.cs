using HR.Application.JobPostAppService;
using HR.Application.JobPostAppService.Dtos;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace HR.Host.Controllers
{
    public class JobPostController : BaseController<IJobPostAppService, Domain.Models.JobPost, JobPostGetAllDto, JobPostGetDto, JobPostCreateDto, JobPostUpdateDto, SieveModel>
    {
        public JobPostController(IJobPostAppService appService) : base(appService, Servics.HR)
        {
        }
    }
}
