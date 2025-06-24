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
using MimeKit.Encodings;
using QRCoder;
using iTextSharp.text.pdf.qrcode;
using Loyalty.Domain.Models;
using Infrastructure.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using AutoMapper.Execution;

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


            var memberTier = await _memberTierDetailsAppService.Create(new MemberTierDetailsCreateDto
            {
                TierId = tierDetails.Id,
                MemberDemographicsAndProfileId = createdProfile.Id,
                EndDate = DateTime.MaxValue
            });



            await _memberAccrualTransactionsAppService.Create(new MemberAccrualTransactions.Dtos.MemberAccrualTransactionsCreateDto
            {
                CIS = result.Code,
                PartnerCode = PartnerCode.FlyCham,
                LoadDate = DateTime.Now,
                Description = "Enrolment Bonus",
                TierId = memberTier.Id,
                Base = 0,
                Bonus = 400
            });
            if(Bonus ==100)
                await _memberAccrualTransactionsAppService.Create(new MemberAccrualTransactions.Dtos.MemberAccrualTransactionsCreateDto
                {
                    CIS = result.Code,
                    PartnerCode = PartnerCode.FlyCham,
                    LoadDate = DateTime.Now,
                    Description = "Self Enrolment Bonus",
                    Base = 0,
                    Bonus = 100,
                    TierId = memberTier.Id
                });
            return await Get(createdProfile.Id);
        }


        public async Task UpgradeUserTier(string cis)
        {
            var res = await _serviceDbContext.MemberDemographicsAndProfiles.Where(x => x.UserCode == cis).FirstOrDefaultAsync();
            if (res == null) return;

            var allTransactions = _serviceDbContext.MemberAccrualTransactions
                .Where(x => x.TierValidationDate >= DateTime.Now && x.CIS == cis)
                .ToList();

            //var minTierValidationDate = allTransactions.Min(x => x.TierValidationDate);

            var totalTierMiles = allTransactions.Sum(x => (x.Base ?? 0));

            var member = await this.Get(res.Id);
            var lastCard =  member.MemberTierDetails.OrderByDescending(x => x.FulfillDate).FirstOrDefault();

            List<TierDetails> availableTiers = _serviceDbContext.TierDetails.OrderByDescending(x => x.RequiredMilesToReach).ToList();
            foreach (var item in availableTiers)
            {
                if(item.RequiredMilesToReach <= totalTierMiles)
                {
                    if (lastCard.TierDetails.Id != item.Id || lastCard.EndDate < DateTime.Now)
                    {
 
                        await _memberTierDetailsAppService.Create(new MemberTierDetailsCreateDto
                        {
                            TierId = item.Id,
                            MemberDemographicsAndProfileId = res.Id,
                            EndDate = item.TireLifeSpanYears == -1? DateTime.MaxValue :DateTime.Now.AddYears(item.TireLifeSpanYears) //    if it is blue card the card validation should be unlimited
                        });
                    }


                    break;
                }
            }
        }

        public async Task UpgradeAllUserTier()
        {
            var usersWithExpiredLastCard = await _serviceDbContext.MemberDemographicsAndProfiles
                .Select(user => new
                {
                    User = user,
                    LastCard = _serviceDbContext.MemberTierDetails
                        .Where(c => c.MemberDemographicsAndProfileId == user.Id)
                        .OrderByDescending(c => c.FulfillDate)
                        .FirstOrDefault()
                })
                .Where(x => x.LastCard != null && DateTime.Now > x.LastCard.FulfillDate) // expired check
                .ToListAsync();


            foreach (var user in usersWithExpiredLastCard)
                await this.UpgradeUserTier(user.User.UserCode);

        }



        public async Task<ActionResult<SummaryGetDto>> GetUserSummary()
        {
            var cis = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;

            var res = await _serviceDbContext.MemberDemographicsAndProfiles.Where(x => x.UserCode == cis).FirstOrDefaultAsync();
            if (res == null) throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("File", "Invalid file path.") });
            

            var allTransactions = _serviceDbContext.MemberAccrualTransactions
                .Where(x => x.TierValidationDate >= DateTime.Now && x.CIS == cis)
                .ToList();

            var totalTierMiles = allTransactions.Sum(x => (x.Base ?? 0));

            var member = await this.Get(res.Id);
            var lastCard = member.MemberTierDetails.OrderByDescending(x => x.FulfillDate).FirstOrDefault();

            List<TierDetails> availableTiers = _serviceDbContext.TierDetails.OrderByDescending(x => x.RequiredMilesToReach).ToList();

            int totalMilesToReach = int.MaxValue;
            TierDetails nextCard = null;
            foreach (var item in availableTiers)
            {
                int dif = item.RequiredMilesToReach - totalTierMiles;
                if (dif >= 0 && totalMilesToReach > dif )
                {
                    totalMilesToReach = dif;
                    nextCard = item;
                }

            }

            var lastTransaction = _serviceDbContext.MemberAccrualTransactions.OrderByDescending(x => x.LoadDate).FirstOrDefault();
            return new SummaryGetDto
            {
                currentCardName = lastCard.TierDetails.Name,
                nextCardName = nextCard.Name,
                LastTransactionDate = lastTransaction.LoadDate,
                TotalAccuareMileToReach = totalMilesToReach

            };
        }
 

        public async Task<ActionResult<MemberDemographicsAndProfileGetDto>> GetMemberDemographicsAndProfileGetDtoByUserCode()
        {
            var userCode = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
            var result = await QueryExcuter(null).FirstOrDefaultAsync(x => x.UserCode.Equals(userCode)) ??
                throw new EntityNotFoundException(typeof(Domain.Models.MemberDemographicsAndProfile).Name, "User Code", userCode.ToString() ?? "");
            return await Task.FromResult(_mapper.Map<MemberDemographicsAndProfileGetDto>(result));
        }
    }
}
