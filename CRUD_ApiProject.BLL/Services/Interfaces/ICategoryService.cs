using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_ApiProject.DAL.DTO.Requests;
using CRUD_ApiProject.DAL.DTO.Responses;
using CRUD_ApiProject.DAL.Models;

namespace CRUD_ApiProject.BLL.Services.Interfaces
{
    public interface ICategoryService: IGenericService<CategoryRequest, CategoryResponse,Category>
    {

}
}
