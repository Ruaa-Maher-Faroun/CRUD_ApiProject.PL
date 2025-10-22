using CRUD_ApiProject.DAL.DTO.Requests;
using CRUD_ApiProject.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.BLL.Services.Interfaces
{
    public interface IGenericService<TRequest,TResponse,TEntity>
    {
        int Create(TRequest request);
        int Update(int id, TRequest request);
        int Delete(int id);
        IEnumerable<TResponse>? GetAll(bool onlyActive=false);
        TResponse? GetById(int id);
        bool ToggleStatus(int id);
    }
}
