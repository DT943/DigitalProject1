using Infrastructure.Service.Controllers;
using Sieve.Models;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.FileAppservice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Drawing;
using System.Drawing.Imaging;

using Xabe.FFmpeg;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using Gallery.Application.FileAppservice.Validations;
using FluentValidation;
using static Infrastructure.Domain.Consts;


namespace Gallery.Host.Controllers
{
    [Authorize]
    public class FileController : BaseController<IFileAppService, Domain.Models.File, FileGetDto, FileGetDto, FileCreateDto, FileUpdateDto, SieveModel>
    {
        IFileAppService _appService;
        FileValidator _fileValidator;
        public FileController(IFileAppService appService, FileValidator fileValidator) : base(appService, Servics.GALLERY)
        {
          
            _appService = appService;
            _fileValidator= fileValidator;
        }


        [RequestSizeLimit(1_000_000_000)] // 1GB
        [RequestFormLimits(MultipartBodyLengthLimit = 1_000_000_000)]
        public override async Task<ActionResult<FileGetDto>> Create(FileCreateDto createDto)
        {
            return await base.Create(createDto);
        }


        [RequestSizeLimit(1_000_000_000)] // 1GB
        [RequestFormLimits(MultipartBodyLengthLimit = 1_000_000_000)]
        [HttpPost("upload-multi-files")]
        public async Task<ActionResult<List<FileGetDto>>> CreateMultipleFiles([FromForm]MultiFileCreateDto createDto)
        {
            if (!UserHasPermission("Admin", "Manager", "Supervisor", "Officer"))
            {
                return Forbid();
            }
            return await _appService.CreateMultipleFiles(createDto);
        }
        [AllowAnonymous]
        [RequestSizeLimit(1_000_000_000)] // 1GB
        [RequestFormLimits(MultipartBodyLengthLimit = 1_000_000_000)]
        [HttpPost("MultiImagesOcr")]
        public async Task<ActionResult<List<FileWithOCRGetDto>>> CreateMultipleImages([FromForm] MultiFileCreateDto createDto)
        {
            //dev "Gallery_7d139144-efd4-4c5f-96ab-a3aa4a7e3a12";//
            createDto.GalleryCode = "Gallery_bbe8a568-2b1d-4499-a2fe-02f218871365"; //production Passport GalleryCode
            return await _appService.CreateMultipleImages(createDto);
        }

        [HttpGet("getby-galleryid/{galleryId}")]
        public virtual async Task<ActionResult<List<FileGetDto>>> GetFilesByGalleryId(int galleryId)
        {
            if (!UserHasPermission("Admin", "Manager", "Supervisor", "Officer"))
            {
                return Forbid();
            }
            var files = await _appService.GetRelatedFileGallery(galleryId);
            return Ok(files);
        }

        [HttpGet("getby-gallerycode/{gallerycode}")]
        public virtual async Task<ActionResult<List<FileGetDto>>> GetFilesByGalleryCodeAsync(string galleryCode)
        {
            if (!UserHasPermission("Admin", "Manager", "Supervisor", "Officer"))
            {
                return Forbid();
            }

            var files = await _appService.GetRelatedFileGalleryByCodeAsync(galleryCode);
            return Ok(files);
        }

    }
}
