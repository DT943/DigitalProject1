using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService.Validations;
using Loyalty.Application.MemberAddressDetailsAppService;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Authentication.Domain.Models;
using Authentication.Application;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberAccrualTransactions;
using Loyalty.Application.MemberTierDetailsAppService;
using Loyalty.Application.TierDetailsAppService;
using Loyalty.Application.MemberTierDetailsAppService.Dto;
using Microsoft.EntityFrameworkCore;

namespace Loyalty.Application.MemberDemographicsAndProfileAppService
{
    public class MemberDemographicsAndProfileAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberDemographicsAndProfile, MemberDemographicsAndProfileGetAllDto, MemberDemographicsAndProfileGetDto, MemberDemographicsAndProfileCreateDto, MemberDemographicsAndProfileUpdateDto, SieveModel>, IMemberDemographicsAndProfileAppService
    {

        IAuthenticationAppService _authenticationAppService;
        IMemberAccrualTransactionsAppService _memberAccrualTransactionsAppService;
        IMemberTierDetailsAppService _memberTierDetailsAppService;
        ITierDetailsAppService _tierDetailsAppService;

        public MemberDemographicsAndProfileAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberDemographicsAndProfileValidator validations, 
            IHttpContextAccessor httpContextAccessor, 
            IAuthenticationAppService authenticationAppService, 
            IMemberAccrualTransactionsAppService memberAccrualTransactionsAppService, 
            IMemberTierDetailsAppService memberTierDetailsAppService,
            ITierDetailsAppService tierDetailsAppService) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _authenticationAppService = authenticationAppService;
            _memberAccrualTransactionsAppService = memberAccrualTransactionsAppService;
            _memberTierDetailsAppService = memberTierDetailsAppService;
            _tierDetailsAppService = tierDetailsAppService;
        }

        protected override IQueryable<Domain.Models.MemberDemographicsAndProfile> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input).Include(x => x.MemberTierDetails).ThenInclude(x => x.TierDetails);
        }
        public override async Task<MemberDemographicsAndProfileGetDto> Create(MemberDemographicsAndProfileCreateDto createDto)
        {

            var validationResult = await _validations.ValidateAsync(createDto, options => options.IncludeRuleSets("createwithuser", "default"));
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var result = await _authenticationAppService.AddLoyaltyUserAsync(new Authentication.Application.Dtos.AddUserDto
            {
                FirstName = createDto.FirstName,
                LastName = createDto.LastName,
                Email = createDto.Email
            });

            createDto.UserCode = result.Code;

            return await base.Create(createDto);
        }
        public async Task<MemberDemographicsAndProfileGetDto> CreateWithBonus(MemberDemographicsAndProfileCreateDto createDto, int Bonus)
        {
            
            var validationResult = await _validations.ValidateAsync(createDto, options => options.IncludeRuleSets("createwithuser", "default"));
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var result = await _authenticationAppService.AddLoyaltyUserAsync(new Authentication.Application.Dtos.AddUserDto
            {
                FirstName = createDto.FirstName,
                LastName = createDto.LastName,
                Email = createDto.Email
            });

            createDto.UserCode = result.Code;


            var tierDetails = await _tierDetailsAppService.GetByName("Blue");

            var createdProfile =  await base.Create(createDto);


            await _memberTierDetailsAppService.Create(new MemberTierDetailsCreateDto
            {
                TierId = tierDetails.Id,
                MemberDemographicsAndProfileId = createdProfile.Id
            });



            await _memberAccrualTransactionsAppService.Create(new MemberAccrualTransactions.Dtos.MemberAccrualTransactionsCreateDto
            {
                CIS = result.Code,
                PartnerCode = "Cham Wings",
                LoadDate = DateTime.Now,
                Description = "Enrolment Bonus",
                Base = 0,
                Bonus = 400
            });
            if(Bonus ==100)
                await _memberAccrualTransactionsAppService.Create(new MemberAccrualTransactions.Dtos.MemberAccrualTransactionsCreateDto
                {
                    CIS = result.Code,
                    PartnerCode = "Cham Wings",
                    LoadDate = DateTime.Now,
                    Description = "Enrolment Bonus",
                    Base = 0,
                    Bonus = 100
                });
            return await Get(createdProfile.Id);
        }
    }
}
