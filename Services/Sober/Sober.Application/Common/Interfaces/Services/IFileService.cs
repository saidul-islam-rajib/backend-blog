using Microsoft.AspNetCore.Http;

namespace Sober.Application.Common.Interfaces.Services;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile file, string subFolder = "uploads");
    bool DeleteFileAsync(string path);
}
