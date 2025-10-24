using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.DAL.DTO.Requests
{
    public class BrandRequest
    {
        public string Name { get; set; }
        public IFormFile MainImage { get; set; }
    }

}
