using DotNetWebAPI.Daos;
using DotNetWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public FilesController(ApplicationDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        [Authorize]
        [HttpPost("process")]
        public async Task<IActionResult> ProcessFiles([FromBody] Payload payload)
        {
            if (payload == null || payload.Files == null || payload.Files.Count == 0)
            {
                return BadRequest("Invalid payload.");
            }

            // Save initial data to database
            await SaveDataToDatabase(payload);

            // Download files asynchronously
            var downloadTasks = payload.Files.Select(file => DownloadFileAsync(file.FileUrl));
            await Task.WhenAll(downloadTasks);

            // Update file statuses to completed
            await UpdateFileStatus(payload.Files);

            return Ok("Files processed successfully.");
        }

        private async Task SaveDataToDatabase(Payload payload)
        {
            foreach (var file in payload.Files)
            {
                var fileStatus = new FileStatus
                {
                    PersonId = payload.PersonId,
                    FileName = file.FileName,
                    Status = "Inprogress"
                };

                _context.FileStatuses.Add(fileStatus);
            }

            await _context.SaveChangesAsync();
        }

        private async Task UpdateFileStatus(List<FileData> files)
        {
            foreach (var file in files)
            {
                var fileStatus = await _context.FileStatuses
                    .SingleOrDefaultAsync(fs => fs.FileName == file.FileName);

                if (fileStatus != null)
                {
                    fileStatus.Status = "Completed";
                }
            }

            await _context.SaveChangesAsync();
        }

        private async Task DownloadFileAsync(string fileUrl)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(fileUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                // Save content to file system or process as needed
            }
            else
            {
                // Handle failure to download the file
            }
        }
    }

    public class Payload
    {
        public string PersonId { get; set; }
        public string Name { get; set; }
        public List<FileData> Files { get; set; }
    }

    public class FileData
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
    }
}
