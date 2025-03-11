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
            createDto.Size = fileSizeBytes;
            createDto.FileUrlPath = fileUrl;
            return await base.Create(createDto);

        }

        public override async Task<ActionResult<FileGetDto>> Update(FileUpdateDto updateDto)
        {
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

            // Update DTO directly
            updateDto.FileType = fileType;
            updateDto.MimeType = contentType;
            long fileSizeBytes = new FileInfo(updateDto.Path).Length;

            updateDto.Size = fileSizeBytes;


            return await base.Update(updateDto);

        }



        public async override Task<ActionResult<FileGetDto>> Get(int id)
        {

            FileGetDto fileGetDto = _appService.Get(id).Result;

            var filePath = fileGetDto.Path;

            if (!System.IO.File.Exists(filePath))
            {
                return BadRequest("Invalid file path.");
            }


            // Extract the file name
            var fileName = Path.GetFileName(filePath);

            // Base URL where static files are served
            var baseUrl = $"{Request.Scheme}://{Request.Host}/images";
            var fileUrl = $"{baseUrl}/{fileName}";

            // Determine MIME type
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }


            // Extract file type safely
            var fileType = contentType.Contains("/") ? contentType.Split("/")[0] : "unknown";

            // Update DTO directly
            fileGetDto.FileType = fileType;
            fileGetDto.MimeType = contentType;
            long fileSizeBytes = new FileInfo(filePath).Length;

            fileGetDto.Size = fileSizeBytes/(1024*1024);

            return Ok(fileGetDto);
        }
        


        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(FileUploadModel model)
        {
            if (model.File != null && model.File.Length > 0)
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "images");

                // Create the folder if it doesn't exist
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var filePath = Path.Combine(folderPath, model.File.FileName);

                // Save the file to the folder
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.File.CopyToAsync(fileStream);
                }

                return Ok(new { filePath });
            }

            return BadRequest("No file uploaded.");
        }

        [HttpPost("GetFile")]
        public IActionResult GetFileAsync([FromBody] FilePostModel file)
        {
            var filePath = file.FilePath;

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            // Extract the file name
            var fileName = Path.GetFileName(filePath);

            // Base URL where static files are served
            var baseUrl = $"{Request.Scheme}://{Request.Host}/images";
            var fileUrl = $"{baseUrl}/{fileName}";

            // Determine MIME type
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            // Return URL instead of file
            var fileGetModel = new FileGetModel
            {
                FilePhysicalPath = PhysicalFile(filePath, contentType),
                FileUrlPath = fileUrl,
            };

            return Ok(fileGetModel);
        }
    }
}
