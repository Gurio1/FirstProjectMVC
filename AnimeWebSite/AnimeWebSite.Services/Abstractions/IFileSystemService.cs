using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeWebSite.Services.Abstractions
{
    public interface IFileSystemService
    {
        string Create(IFormFile file, string folderName,int? userId);
        bool DeleteFile(string filePath);
    }
}
