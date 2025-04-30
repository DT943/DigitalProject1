 
using AutoMapper; 
using CMS.Data.DbContext;
using Infrastructure.Application;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using CMS.Application.CustomFormAppService.Dto;
using CMS.Application.CustomFormAppService.Validations;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Application.Validations;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Infrastructure.Application.EmailValidation;
namespace CMS.Application.CustomFormAppService
{
    public class CustomFormAppService : BaseAppService<CMSDbContext, Domain.Models.CustomForm, CustomFormGetDto, CustomFormGetDto, CustomFormCreateDto, CustomFormUpdateDto, SieveModel>, ICustomFormAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        CMSDbContext _serviceDbContext;
        CustomFormValidator _validations;
        IConfiguration _configuration;
        public CustomFormAppService(CMSDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, CustomFormValidator validations, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _serviceDbContext = serviceDbContext;
            _validations = validations;
        }
        public  override  async Task<CustomFormGetDto> Create(CustomFormCreateDto create)
        {
            var validationResult = await _validations.ValidateAsync(create, options => options.IncludeRuleSets("create", "default"));
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            string emailValidationApiKey = _configuration["EmailValidation:ApiKey"];
            Console.WriteLine("emailValidationApiKey:" + emailValidationApiKey);
            var Result = await EmailValidation.GetEmailValidationScore(emailValidationApiKey, create.Email);

            create.IsValid = Result;
            return await base.Create(create);
        }

        protected override IQueryable<Domain.Models.CustomForm> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
