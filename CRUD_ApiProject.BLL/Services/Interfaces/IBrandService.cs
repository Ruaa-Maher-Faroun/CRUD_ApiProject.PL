using CRUD_ApiProject.DAL.DTO.Requests;
using CRUD_ApiProject.DAL.DTO.Responses;
using CRUD_ApiProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.BLL.Services.Interfaces
{
    public interface IBrandService : IGenericService<BrandRequest, BrandResponse, Brand>
    {
    }
}
