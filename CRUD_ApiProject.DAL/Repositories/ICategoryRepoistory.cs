using CRUD_ApiProject.DAL.Models;

namespace CRUD_ApiProject.DAL.Repository
{
    public interface ICategoryRepoistory
    {
        int Add(Category category);
        IEnumerable<Category> GetAll(bool withTracking = false);
        int Update(Category category);
        int Remove(Category category);
        Category GetById(int id);
    }
}