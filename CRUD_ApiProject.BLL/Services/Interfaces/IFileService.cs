using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.BLL.Services.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file,string folder);
        Task<bool> DeleteAsync(string fileName, string folder);

        Task<bool> UpdateAsync(IFormFile file, string fileName, string folder);

    }
}
