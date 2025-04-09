using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BranchesManagement.Application.BranchesManagementAppService.Dto;
using BranchesManagement.Application.BranchesManagementAppService.Validations;
using BranchesManagement.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;

namespace BranchesManagement.Application.BranchesManagementAppService
{
    public class BranchesManagementAppService : BaseAppService<BranchesManagementDbContext, Domain.Models.Branch, BranchesManagementGetAllDto ,BranchesManagementGetDto, BranchesManagementCreateDto, BranchesManagementUpdateDto, SieveModel>, IBranchesManagementAppService
    {
        public BranchesManagementAppService(BranchesManagementDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, BranchesManagementValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {


        }
    }
}
