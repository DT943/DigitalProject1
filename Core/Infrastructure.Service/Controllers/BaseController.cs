
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Application;
using Infrastructure.Domain.Models;
using Sieve.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<TAppService, TEntity, TGetAllDto, TGetDto,TCreatDto,TUpdateDto, TFilterDto>
        : ControllerBase,
        IBaseController<TAppService, TEntity, TGetAllDto, TGetDto, TCreatDto, TUpdateDto, TFilterDto>
        where TAppService : IBaseAppService< TGetAllDto,TGetDto, TCreatDto, TUpdateDto, TFilterDto>
        where TEntity : BasicEntity
        where TFilterDto : SieveModel
    {
        protected bool UserHasPermission(params string[] requiredRoles)
        {
            var user = HttpContext.User;

            if (user.IsInRole("SuperAdmin")) return true; 

            foreach (var role in requiredRoles)
            {
                var servicerole = $"{ServiceName}-{role}";
                if (user.IsInRole(servicerole))
                    return true;
            }
            return false;
        }

        protected readonly TAppService _appService;
        protected readonly string ServiceName;
        public BaseController(TAppService appService, string serviceName)
        {
            _appService = appService;
            ServiceName = serviceName;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public virtual async Task<ActionResult<TGetDto>> Create(TCreatDto dto)
        {
            if (!UserHasPermission("Admin", "Manager", "Supervisor","Officer"))
            {
                return Forbid();
            }

            var entity = await _appService.Create(dto);
            return Ok(entity);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public virtual async Task<ActionResult<TGetDto>> Update(TUpdateDto dto)
        {
            if (!UserHasPermission("Admin", "Manager"))
            {
                return Forbid();
            }
            return Ok(await _appService.Update(dto));
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public virtual async Task<ActionResult<TGetDto>> Get(int id)
        {
            var user = HttpContext.User;

            if (!UserHasPermission("Admin", "Manager", "Supervisor", "Officer"))
            {
                return Forbid();
            }
            var entity = await _appService.Get(id);
            return Ok(entity);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public virtual async Task<ActionResult<TGetAllDto>> GetAll([FromQuery] TFilterDto sieve)
        {
            var user = HttpContext.User;

            if (!UserHasPermission("Admin", "Manager", "Supervisor", "Officer"))
            {
                return Forbid();
            }
            var entity = await _appService.GetAll(sieve);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public virtual async Task<ActionResult<TGetDto>> Delete(int id)
        {
            var user = HttpContext.User;
            if (!UserHasPermission())
            {
                return Forbid();
            }
            var deletedEntity = await _appService.Delete(id);
            return Ok(deletedEntity);
        }

        [HttpDelete("{id}/{delete}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public virtual async Task<ActionResult<TGetDto>> FakeDelete(int id, bool delete)
        {
            var user = HttpContext.User;

            if (!UserHasPermission("Admin", "Manager"))
            {
                return Forbid();
            }

            var deletedEntity = await _appService.FakeDelete(delete, id);

            if (deletedEntity == null)
            {
                return NotFound();
            }

            return Ok(deletedEntity);
        }

    }


}
