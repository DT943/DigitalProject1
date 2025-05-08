using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BranchesManagement.Application.BranchesManagementAppService.Dto
{
    public class BranchesManagementMapperProfile : Profile
    {
        public BranchesManagementMapperProfile()
        {
            CreateMap<Domain.Models.Branch, BranchesManagementGetDto>();
            CreateMap<Domain.Models.Branch, BranchesManagementGetAllDto>();
            CreateMap<BranchesManagementCreateDto, Domain.Models.Branch>();
            CreateMap<BranchesManagementUpdateDto, Domain.Models.Branch>();
        }
    }
}
