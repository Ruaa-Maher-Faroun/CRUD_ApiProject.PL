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
        public async Task<string> UploadAsync(IFormFile file)
        {
            if (file != null && file.Length > 0) 
            { 
                var fileName= Guid.NewGuid().ToString();    
                return fileName;
            }
            throw new Exception("ERROR");
        }
    }
}
