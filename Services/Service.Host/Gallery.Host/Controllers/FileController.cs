using Gallery.Application.GalleryAppService.Dtos;
using Gallery.Application.GalleryAppService;
using Infrastructure.Service.Controllers;
using Sieve.Models;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.FileAppservice;
using Microsoft.AspNetCore.Authorization;

namespace Gallery.Host.Controllers
{
    [Authorize]
    public class FileController : BaseController<IFileAppService, Domain.Models.File, FileGetDto, FileCreateDto, FileUpdateDto, SieveModel>
    {
        IFileAppService _appService;
        public FileController(IFileAppService appService) : base(appService)
        {
            _appService = appService;
        }
    }
}
