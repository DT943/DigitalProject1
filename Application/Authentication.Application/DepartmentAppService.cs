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
        private readonly ISieveProcessor _sieveProcessor;

        public DepartmentAppService(
            ApplicationDbContext dbContext,
            IMapper mapper,
            IValidator<CreateDepartmentDto> createValidator,
            IHttpContextAccessor httpContextAccessor,
            ISieveProcessor sieveProcessor)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _createValidator = createValidator;

            _httpContextAccessor = httpContextAccessor;
            _sieveProcessor = sieveProcessor;

        }

        public async Task<DepartmentGetDto> Create(CreateDepartmentDto dto)
        {
            // Check if a department with the same name already exists
            var exists = await _dbContext.Departments
                .AnyAsync(d => d.DepartmentName.ToLower() == dto.DepartmentName.ToLower().Trim());

            if (exists)
                throw new InvalidOperationException($"A department already exists.");

            // Validate the input
            var validationResult = await _createValidator.ValidateAsync(dto, options =>
            {
                options.IncludeRuleSets("create", "default");
            });
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // Map and set additional fields
            var department = _mapper.Map<Department>(dto);
            department.Code = "Department_" + Guid.NewGuid().ToString();
            department.CreatedBy = _httpContextAccessor.HttpContext?.User?.FindFirst("userCode")?.Value;
            department.CreatedDate = DateTime.Now;

            // Save to DB
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

        public async Task<PaginatedResult<DepartmentGetDto>> GetAll(SieveModel sieveModel)
        {
            // Start with IQueryable for filtering/sorting/pagination
            var query = _dbContext.Departments.AsNoTracking();

            // Apply filtering and sorting
            query = _sieveProcessor.Apply(sieveModel, query, applyPagination: false);

            // Count total after filtering
            var totalCount = await query.CountAsync();

            // Apply pagination
            query = _sieveProcessor.Apply(sieveModel, query, applyFiltering: false, applySorting: false);

            // Fetch paginated result
            var pagedDepartments = await query.ToListAsync();

            // Map to DTO
            var departmentRes = _mapper.Map<List<DepartmentGetDto>>(pagedDepartments);

            return new PaginatedResult<DepartmentGetDto>
            {
                Items = departmentRes,
                TotalCount = totalCount,
                Page = sieveModel.Page ?? 1,
                PageSize = sieveModel.PageSize ?? totalCount
            };

        }

        public async Task<DepartmentGetDto> GetByCode(string code)
        {
            var entity = await _dbContext.Departments
                            .FirstOrDefaultAsync(x => x.Code == code)
                         ?? throw new EntityNotFoundException(nameof(Department), code);

            return _mapper.Map<DepartmentGetDto>(entity);
        }

        public async Task<DepartmentGetDto> Update(UpdateDepartmentDto dto)
        {
            // Fetch the existing department
            var entity = await _dbContext.Departments
                                .FirstOrDefaultAsync(x => x.Id == dto.Id)
                             ?? throw new EntityNotFoundException(nameof(Department), dto.Id.ToString());

            // Check if the updated name exists in another department
            var duplicateExists = await _dbContext.Departments
                .AnyAsync(d => d.Id != dto.Id && d.DepartmentName.ToLower() == dto.DepartmentName.ToLower().Trim());

            if (duplicateExists)
                throw new InvalidOperationException($"A department already exists.");

            // Map changes to the entity
            _mapper.Map(dto, entity);
            entity.ModifiedBy = _httpContextAccessor.HttpContext?.User?.FindFirst("userCode")?.Value;
            entity.ModifiedDate = DateTime.Now;

            // Save changes
            _dbContext.Departments.Update(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<DepartmentGetDto>(entity);
        }


    }
}
