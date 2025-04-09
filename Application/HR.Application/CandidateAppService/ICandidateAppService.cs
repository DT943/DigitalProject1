using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Application.CandidateAppService.Dtos;
using HR.Application.JobPostAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace HR.Application.CandidateAppService
{
    public interface ICandidateAppService : IBaseAppService<CandidateGetAllDto, CandidateGetDto, CandidateCreateDto, CandidateUpdateDto, SieveModel>
    {
    }
}
