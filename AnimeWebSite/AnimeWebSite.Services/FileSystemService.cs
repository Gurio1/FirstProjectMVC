using AnimeWebSite.Services.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AnimeWebSite.Services
{
    public class FileSystemService : IFileSystemService
    {
        private readonly IHostingEnvironment _appEnvironmen;

        public const string animeImages = "AnimeImages";
        public const string userImages = "UserImages";
        public FileSystemService(IHostingEnvironment appEnvironmen)
        {
            _appEnvironmen = appEnvironmen;
        }
        public string Create(IFormFile file, string folderName, int? entityId = null)
        {
            var userFolder = entityId?.ToString();

            var path = $"/File/{folderName}";

            var pathWithEnviroment = _appEnvironmen.WebRootPath;
            if (file != null)
            {
                if (userFolder is null)
                {
                    path = Path.Combine(path, file.FileName);
                }
                else
                {
                    path = Path.Combine(path, userFolder);

                    pathWithEnviroment = pathWithEnviroment + path;

                    if (!Directory.Exists(pathWithEnviroment))
                    {
                        Directory.CreateDirectory(pathWithEnviroment);
                    }

                    path = path + "/" + file.FileName;
                }

                pathWithEnviroment = _appEnvironmen.WebRootPath + path;
                using (var stream = new FileStream(pathWithEnviroment, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
            }
            return path;
        }

        public bool DeleteFile(string filePath)
        {
            var defaultPath = $"/Files/{userImages}/UserDefaultImage/DefaultImage.jpg";
            try
            {
                if (filePath == defaultPath) return true;
                File.Delete(_appEnvironmen.WebRootPath + filePath);
            }
            catch
            {

                return false;
            }

            return true;
        }
    }
}
