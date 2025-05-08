using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BranchesManagement.Application.BranchesManagementAppService.Dto;
using Infrastructure.Application;
using Sieve.Models;

namespace BranchesManagement.Application.BranchesManagementAppService
{
    public interface IBranchesManagementAppService : IBaseAppService<BranchesManagementGetAllDto,BranchesManagementGetDto, BranchesManagementCreateDto, BranchesManagementUpdateDto, SieveModel>
    {
    }
}
