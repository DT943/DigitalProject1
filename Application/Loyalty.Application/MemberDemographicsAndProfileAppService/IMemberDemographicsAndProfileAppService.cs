using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Loyalty.Application.MemberDemographicsAndProfileAppService
{
    public interface IMemberDemographicsAndProfileAppService : IBaseAppService<MemberDemographicsAndProfileGetAllDto, MemberDemographicsAndProfileGetDto, MemberDemographicsAndProfileCreateDto, MemberDemographicsAndProfileUpdateDto, SieveModel>
    {
        public Task<MemberDemographicsAndProfileGetDto> CreateWithBonus(MemberDemographicsAndProfileCreateDto createDto, int Bonus);

        public Task UpgradeUserTier(string cis);

        public Task<ActionResult<SummaryGetDto>> GetUserSummary();
 
        public Task<ActionResult<MemberDemographicsAndProfileGetDto>> GetMemberDemographicsAndProfileGetDtoByUserCode();

    }
}
