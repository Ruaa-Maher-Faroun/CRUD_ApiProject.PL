using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using CRUD_ApiProject.BLL.Services.Interfaces;
using CRUD_ApiProject.DAL.DTO.Requests;
using CRUD_ApiProject.DAL.DTO.Responses;
using CRUD_ApiProject.DAL.Models;
using CRUD_ApiProject.DAL.Repositories.Interfaces;
using Mapster;

namespace CRUD_ApiProject.BLL.Services.Classes
{
    public class CategoryService : GenericService<CategoryRequest, CategoryResponse,Category> , ICategoryService
    {
        public CategoryService(ICategoryRepoistory iCategoryRepository):base(iCategoryRepository)
        {
        }

    }
}
