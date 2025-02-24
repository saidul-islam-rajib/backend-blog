using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Sober.Application.Common.Interfaces.Services;

namespace Sober.Infrastructure.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _environment;
    private readonly string[] _allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

    public FileService(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<string> SaveFileAsync(IFormFile file, string subFolder = "uploads")
    {
        if (file == null)
        {
            return String.Empty;
        }

        // Validate file type
        var fileExtension = Path.GetExtension(file.FileName).ToLower();
        if (!_allowedExtensions.Contains(fileExtension))
        {
            throw new ArgumentException("Invalid file format. Only .jpg, .jpeg, and .png are allowed.");
        }

        // Generate a unique filename while keeping the original name
        string originalFileName = Path.GetFileNameWithoutExtension(file.FileName)
                                  .Replace(" ", "_")  // Replace spaces with underscores to avoid URL issues
                                  .ToLower();

        string uniqueFileName = $"{originalFileName}_{Guid.NewGuid()}{fileExtension}";

        // Save the file in wwwroot/uploads
        string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadsFolder);

        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        // Save the file
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/uploads/{uniqueFileName}";
    }
}
