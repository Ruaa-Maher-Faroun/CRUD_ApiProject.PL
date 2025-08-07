using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_ApiProject.DAL.DTO.Requests;
using CRUD_ApiProject.DAL.DTO.Responses;

namespace CRUD_ApiProject.BLL.Services
{
    public interface ICategoryService
    {
        int CreateCategory(CategoryRequest request);
        int UpdateCategory(int id, CategoryRequest request);
        int DeleteCategory(int id);
        IEnumerable<CategoryResponse>? GetAllCategories();
        CategoryResponse? GetCategoryById(int id);
        bool ToggleStatus(int id);



}
}
