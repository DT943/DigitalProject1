using Infrastructure.Service.Controllers;
using Sieve.Models;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.FileAppservice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public override async Task<ActionResult<FileGetDto>> Create(FileCreateDto createDto)
        {
            createDto.Path = null;
            if (createDto.File != null && createDto.File.Length > 0)
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "images");

                // Create the folder if it doesn't exist
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var filePath = Path.Combine(folderPath, createDto.File.FileName);

                // Save the file to the folder
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await createDto.File.CopyToAsync(fileStream);
                }
                createDto.Path = filePath;
                //return Ok(new { filePath });
            }
            else
                return BadRequest("No file uploaded.");


            if (createDto == null || string.IsNullOrWhiteSpace(createDto.Path))
            {
                return BadRequest("Invalid file path.");
            }

            if (!System.IO.File.Exists(createDto.Path))
            {
                return NotFound("File Path Not Found");
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(createDto.Path, out var contentType))
            {
                contentType = "application/octet-stream"; // Default MIME type
            }

            // Extract file type safely
            var fileType = contentType.Contains("/") ? contentType.Split("/")[0] : "unknown";

            var fileName = Path.GetFileName(createDto.Path);

            // Base URL where static files are served
            var baseUrl = $"{Request.Scheme}://{Request.Host}/images";
            var fileUrl = $"{baseUrl}/{fileName}";
            // Update DTO directly
            createDto.FileType = fileType;
            createDto.MimeType = contentType;
            long fileSizeBytes = new FileInfo(createDto.Path).Length;
            createDto.Size = (float)(fileSizeBytes/(1024.0*10240.0));
            createDto.FileUrlPath = fileUrl;
            createDto.FileName = fileName;
            return await base.Create(createDto);

        }

        public override async Task<ActionResult<FileGetDto>> Update(FileUpdateDto updateDto)
        {

            FileGetDto fileGetDto = await _appService.Get(updateDto.Id);
            updateDto.Path = fileGetDto.Path;


            if (updateDto == null || string.IsNullOrWhiteSpace(updateDto.Path))
            {
                return BadRequest("Invalid file path.");
            }

            if (!System.IO.File.Exists(updateDto.Path))
            {
                return NotFound("File Path Not Found");
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(updateDto.Path, out var contentType))
            {
                contentType = "application/octet-stream"; // Default MIME type
            }

            // Extract file type safely
            var fileType = contentType.Contains("/") ? contentType.Split("/")[0] : "unknown";

            var fileName = Path.GetFileName(updateDto.Path);

            // Base URL where static files are served
            var baseUrl = $"{Request.Scheme}://{Request.Host}/images";
            var fileUrl = $"{baseUrl}/{fileName}";
            // Update DTO directly
            updateDto.FileType = fileType;
            updateDto.MimeType = contentType;
            long fileSizeBytes = new FileInfo(updateDto.Path).Length;
            updateDto.Size = (float)(fileSizeBytes / (1024.0 * 10240.0));
            updateDto.FileUrlPath = fileUrl;
            updateDto.FileName = fileName;
            return await base.Update(updateDto);

        }
 
        public async override Task<ActionResult<FileGetDto>> Delete(int id)
        {
            FileGetDto fileGetDto = _appService.Get(id).Result;

            var filePath = fileGetDto.Path;

            if (!System.IO.File.Exists(filePath))
            {
                return BadRequest("Invalid file path.");
            }

            var deletedEntity = await _appService.Delete(id);

            if(!_appService.CheckPath(filePath))
            try
            {
                System.IO.File.Delete(filePath);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting file: {ex.Message}");
            }
            return Ok(deletedEntity);
        }



        [HttpGet("getby-galleryid/{galleryId}")]
        public virtual async Task<ActionResult<List<FileGetDto>>> GetFilesByGalleryId(int galleryId)
        {
            var files = await _appService.GetRelatedFileGallery(galleryId);
 

            return Ok(files);
        }

    }
}
