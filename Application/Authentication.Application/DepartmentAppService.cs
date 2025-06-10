using Authentication.Application.Dtos;
using Authentication.Data.DbContext;
using Authentication.Domain.Models;
using AutoMapper;
using FluentValidation;
using Infrastructure.Application.Exceptions;
using Infrastructure.Application.Validations;
using Infrastructure.Data.BaseDbContext;
using Infrastructure.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Notification.Application;
using Sieve.Models;
using Sieve.Services;

namespace Authentication.Application
{
    public class DepartmentAppService : IDepartmentAppService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IValidator<CreateDepartmentDto> _createValidator;

        public DepartmentAppService(
            ApplicationDbContext dbContext,
            IMapper mapper,
            IValidator<CreateDepartmentDto> createValidator,
            IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _createValidator = createValidator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<DepartmentGetDto> Create(CreateDepartmentDto dto)
        {

            var validationResult = await _createValidator.ValidateAsync(dto, options =>
            {
                options.IncludeRuleSets("create", "default");
            });
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var department = _mapper.Map<Department>(dto);
            department.Code = "Department_" + Guid.NewGuid().ToString();

            department.CreatedBy = _httpContextAccessor.HttpContext?.User?.FindFirst("userCode")?.Value;
            department.CreatedDate = DateTime.Now;

            await _dbContext.Departments.AddAsync(department);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<DepartmentGetDto>(department);
        }

        public async Task<DepartmentGetDto> Delete(int id)
        {
            var entity = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id)
                         ?? throw new EntityNotFoundException(nameof(Department), id.ToString());

            _dbContext.Departments.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<DepartmentGetDto>(entity);
        }

        public async Task<DepartmentGetDto> FakeDelete(bool delete,int id)
        {
            var entity = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id)
                         ?? throw new EntityNotFoundException(nameof(Department), id.ToString());

            entity.IsDeleted = delete;
            entity.ModifiedBy = _httpContextAccessor.HttpContext?.User?.FindFirst("userCode")?.Value;
            entity.ModifiedDate = DateTime.Now;

            _dbContext.Departments.Update(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<DepartmentGetDto>(entity);
        }

        public async Task<DepartmentGetDto> Get(int id)
        {
            var entity = await _dbContext.Departments.AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Id == id)
                         ?? throw new EntityNotFoundException(nameof(Department), id.ToString());

            return _mapper.Map<DepartmentGetDto>(entity);
        }

        public async Task<List<DepartmentGetDto>> GetAll()
        {
            List<Department> query = await _dbContext.Departments.ToListAsync();
            return _mapper.Map<List<DepartmentGetDto>>(query);
        }

        public async Task<DepartmentGetDto> GetByCode(string code)
        {
            var entity = await _dbContext.Departments
                            .FirstOrDefaultAsync(x => x.Code == code)
                         ?? throw new EntityNotFoundException(nameof(Department), code);

            return _mapper.Map<DepartmentGetDto>(entity);
        }

        public async Task<DepartmentGetDto> Update(CreateDepartmentDto dto)
        {
            var entity = await _dbContext.Departments
                            .FirstOrDefaultAsync(x => x.DepartmentName == dto.DepartmentName)
                         ?? throw new EntityNotFoundException(nameof(Department), dto.DepartmentName);

            var validationResult = await _createValidator.ValidateAsync(dto, options =>
            {
                options.IncludeRuleSets("create", "default");
            });
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            _mapper.Map(dto, entity);

            entity.ModifiedBy = _httpContextAccessor.HttpContext?.User?.FindFirst("userCode")?.Value;
            entity.ModifiedDate = DateTime.Now;

            _dbContext.Departments.Update(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<DepartmentGetDto>(entity);
        }
    }
}
