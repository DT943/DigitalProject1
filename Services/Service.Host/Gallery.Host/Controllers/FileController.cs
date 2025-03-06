using Infrastructure.Service.Controllers;
using Sieve.Models;
using Gallery.Application.FileAppservice.Dtos;
using Gallery.Application.FileAppservice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Gallery.Host.Controllers
{
    [Authorize]
    public class FileController : BaseController<IFileAppService, Domain.Models.File, FileGetDto, FileCreateDto, FileUpdateDto, SieveModel>
    {
        IFileAppService _appService;
        private readonly IWebHostEnvironment _environment;

        public FileController(IFileAppService appService, IWebHostEnvironment environment) : base(appService)
        {
            _appService = appService;
            _environment = environment;
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
        public async Task<IActionResult> GetImageAsync(FileGetModel file)
        {
            var filePath = file.FilePath;
            //int fileId = file.FileId;

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            // Determine the MIME type
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream"; // Default MIME type if unknown
            }

            // Return the file
            return PhysicalFile(filePath, contentType);
        }
    }
}
