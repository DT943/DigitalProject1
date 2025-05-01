 
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
using Microsoft.EntityFrameworkCore;
using CMS.Domain.Models;
using FluentValidation.Results;
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

            CustomForm cf = await _serviceDbContext.CustomForms.Where(f => f.Email == create.Email).FirstOrDefaultAsync();

            if (cf == null) return await base.Create(create);

            if (cf.LastSubmissionDate == DateTime.Now.Date && cf.NumberofSubmistion > 2)
                throw new FluentValidation.ValidationException(new List<ValidationFailure> { new ValidationFailure("Appliction", $"you can't add your application more than three times") });

            List<string> Services1 = cf.Services.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(s => s.Trim())
                                     .ToList();

            List<string> Services2 = create.Services.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(s => s.Trim())
                                                    .ToList();

            // Get unique union (case-sensitive)
            List<string> uniqueServices = Services1
                .Union(Services2)
                .Distinct()
                .ToList();

            cf.Services = string.Join(",", uniqueServices);
              

            cf.LastSubmissionDate = DateTime.Now.Date;
            cf.NumberofSubmistion++;
            await _serviceDbContext.SaveChangesAsync();

            return await base.Get(cf.Id);
        }

        protected override IQueryable<Domain.Models.CustomForm> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
