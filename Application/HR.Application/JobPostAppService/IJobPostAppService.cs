using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Application.JobPostAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace HR.Application.JobPostAppService
{
    public interface IJobPostAppService : IBaseAppService<JobPostGetAllDto, JobPostGetDto, JobPostCreateDto, JobPostUpdateDto, SieveModel>
    {
    }
}
