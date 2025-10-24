using CRUD_ApiProject.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.BLL.Services.Classes
{
    public class FileService : IFileService
    {
        public async Task<string> UploadAsync(IFormFile file,string folder)
        {
            if (file != null && file.Length > 0) 
            { 
                var fileName= Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", folder, fileName);
                using (var stream = File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                return fileName;
            }
            throw new Exception("ERROR");
        }


        public async Task<bool> DeleteAsync(string fileName, string folder)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", folder, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;

            }

            throw new Exception("ERROR");
        }

        public async Task<bool> UpdateAsync(IFormFile file,string fileName, string folder)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", folder, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                using (var stream = File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
                return true;

            }

            throw new Exception();
        }
    }
}
