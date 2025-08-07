using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using CRUD_ApiProject.DAL.DTO.Requests;
using CRUD_ApiProject.DAL.DTO.Responses;
using CRUD_ApiProject.DAL.Models;
using CRUD_ApiProject.DAL.Repository;
using Mapster;

namespace CRUD_ApiProject.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepoistory iCategoryRepository;
        public CategoryService(ICategoryRepoistory iCategoryRepository)
        {
            this.iCategoryRepository = iCategoryRepository;

        }

        public int CreateCategory(CategoryRequest request)
        {
            var category = request.Adapt<Category>();
            return iCategoryRepository.Add(category);

        }

        public int DeleteCategory(int id)
        {
            var category = iCategoryRepository.GetById(id);
            if (category is null) return 0;
            return iCategoryRepository.Remove(category);
        }

        public IEnumerable<CategoryResponse> GetAllCategories()
        { 
            var categories = iCategoryRepository.GetAll().Adapt<IEnumerable<CategoryResponse>>();
            return categories;
        }

        public CategoryResponse? GetCategoryById(int id)
        {
            var category = iCategoryRepository.GetById(id);
            return category is null ? null : category.Adapt<CategoryResponse>();
        }   

        public int UpdateCategory(int id, CategoryRequest request)
        {
            var category = iCategoryRepository.GetById(id);
            if (category is null) return 0;
            category.Name = request.Name;
            return iCategoryRepository.Update(category);
        }
        public bool ToggleStatus(int id)
        {
            var category = iCategoryRepository.GetById(id);
            if (category is null) return false;
            category.Status = category.Status == Status.Active ? Status.InActive : Status.Active;
            iCategoryRepository.Update(category);
            return true;
        }
    }
}
