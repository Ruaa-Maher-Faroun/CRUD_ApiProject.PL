using CRUD_ApiProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        int Add(T entity);
        IEnumerable<T> GetAll(bool withTracking = false);
        int Update(T entity);
        int Remove(T entity);
        T GetById(int id);

    }
}
