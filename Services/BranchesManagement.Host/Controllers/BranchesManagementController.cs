using BranchesManagement.Application.BranchesManagementAppService;
using BranchesManagement.Application.BranchesManagementAppService.Dto;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace BranchesManagement.Host.Controllers
{
    public class BranchesManagementController : BaseController<IBranchesManagementAppService, Domain.Models.Branch, BranchesManagementGetAllDto, BranchesManagementGetDto, BranchesManagementCreateDto, BranchesManagementUpdateDto, SieveModel>
    {
        public BranchesManagementController(IBranchesManagementAppService appService) : base(appService, Servics.BranchesManagement)
        {
        }
    }
}
