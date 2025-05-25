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

namespace Loyalty.Application.MemberDemographicsAndProfileAppService
{
    public class MemberDemographicsAndProfileAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberDemographicsAndProfile, MemberDemographicsAndProfileGetAllDto, MemberDemographicsAndProfileGetDto, MemberDemographicsAndProfileCreateDto, MemberDemographicsAndProfileUpdateDto, SieveModel>, IMemberDemographicsAndProfileAppService
    {

        IAuthenticationAppService _authenticationAppService;
        IMemberAccrualTransactionsAppService _memberAccrualTransactionsAppService;
        public MemberDemographicsAndProfileAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberDemographicsAndProfileValidator validations, IHttpContextAccessor httpContextAccessor, IAuthenticationAppService authenticationAppService, IMemberAccrualTransactionsAppService memberAccrualTransactionsAppService) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _authenticationAppService = authenticationAppService;
            _memberAccrualTransactionsAppService = memberAccrualTransactionsAppService;
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

            await _memberAccrualTransactionsAppService.Create(new MemberAccrualTransactions.Dtos.MemberAccrualTransactionsCreateDto
            {
                CIS = result.Code,
                PartnerCode = "Cham Wings",
                LoadDate = DateTime.Now,
                Description = "Enrolment Bonus",
                Base = 0,
                Bonus = 400
            });

            return await base.Create(createDto);
        }




    }
}
