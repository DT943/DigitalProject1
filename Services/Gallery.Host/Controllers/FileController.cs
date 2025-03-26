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


namespace Gallery.Host.Controllers
{
    [Authorize]
    public class FileController : BaseController<IFileAppService, Domain.Models.File, FileGetDto, FileGetDto, FileCreateDto, FileUpdateDto, SieveModel>
    {
        IFileAppService _appService;
        FileValidator _fileValidator;
        public FileController(IFileAppService appService, FileValidator fileValidator) : base(appService)
        {
            this.ServiceName = "Gallery";
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
            int i = 0;
            return await _appService.CreateMultipleFiles(createDto);
        }

        [HttpGet("getby-galleryid/{galleryId}")]
        public virtual async Task<ActionResult<List<FileGetDto>>> GetFilesByGalleryId(int galleryId)
        {
            var files = await _appService.GetRelatedFileGallery(galleryId);
 

            return Ok(files);
        }

        [HttpGet("getby-gallerycode/{gallerycode}")]
        public virtual async Task<ActionResult<List<FileGetDto>>> GetFilesByGalleryCodeAsync(string galleryCode)
        {
            var files = await _appService.GetRelatedFileGalleryByCodeAsync(galleryCode);
            return Ok(files);
        }

    }
}
