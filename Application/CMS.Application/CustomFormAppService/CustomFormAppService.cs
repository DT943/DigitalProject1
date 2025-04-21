 
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
namespace CMS.Application.CustomFormAppService
{
    public class CustomFormAppService : BaseAppService<CMSDbContext, Domain.Models.CustomForm, CustomFormGetDto, CustomFormGetDto, CustomFormCreateDto, CustomFormUpdateDto, SieveModel>, ICustomFormAppService
    {
        IHttpContextAccessor _httpContextAccessor;
        CMSDbContext _serviceDbContext;
        CustomFormValidator _validations;
        public CustomFormAppService(CMSDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, CustomFormValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
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
            double Score = await GetEmailValidationScore("a7eced5d157d4cc0862ebe8566f17ecc", create.Email);
            create.Score = Score;
            create.IsValid = Score > 0.9;
            return await base.Create(create);
        }

        public static async Task<double> GetEmailValidationScore(string apiKey, string email)
        {
            string url = $"https://emailvalidation.abstractapi.com/v1/?api_key={apiKey}&email={email}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // Throws exception if the HTTP response status is an error

                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Parse the JSON response to extract the validation score
                    JObject jsonResponse = JObject.Parse(responseBody);
                    double validationScore = jsonResponse["quality_score"].Value<double>(); // Assuming 'quality_score' contains the validation score

                    return validationScore;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                    return -1; // Return -1 to indicate an error
                }
            }
        }

        protected override IQueryable<Domain.Models.CustomForm> QueryExcuter(SieveModel input)
        {
            return base.QueryExcuter(input);
        }
    }
}
