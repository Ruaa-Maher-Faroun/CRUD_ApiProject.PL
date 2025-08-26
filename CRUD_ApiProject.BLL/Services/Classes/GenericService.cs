using Azure;
using Azure.Core;
using CRUD_ApiProject.BLL.Services.Interfaces;
using CRUD_ApiProject.DAL.DTO.Responses;
using CRUD_ApiProject.DAL.Models;
using CRUD_ApiProject.DAL.Repositories.Classes;
using CRUD_ApiProject.DAL.Repositories.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.BLL.Services.Classes
{
    public class GenericService<TRequest, TResponse, TEntity> : IGenericService<TRequest, TResponse, TEntity> where TEntity : BaseModel
    {
        private readonly IGenericRepository<TEntity> _repository;
        public GenericService(IGenericRepository<TEntity> iGenericRepository)
        {
            _repository = iGenericRepository;

        }
        public int Create(TRequest request)
        {
            var entity = request.Adapt<TEntity>();
            return _repository.Add(entity);
        }

        public int Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity is null) return 0;
            return _repository.Remove(entity);
        }

        public IEnumerable<TResponse>? GetAll()
        {
            var entities = _repository.GetAll().Adapt<IEnumerable<TResponse>>();
            return entities;
        }

        public TResponse? GetById(int id)
        {
            var entity = _repository.GetById(id);
            return entity is null ? default : entity.Adapt<TResponse>();
        }

        public bool ToggleStatus(int id)
        {
            var entity = _repository.GetById(id);
            if (entity is null) return false;
            entity.Status = entity.Status == Status.Active ? Status.InActive : Status.Active;
            _repository.Update(entity);
            return true;
        }

        public int Update(int id, TRequest request)
        {
            var entity = _repository.GetById(id);
            if (entity is null) return 0;
            var updatedEntity = request.Adapt(entity);
            return _repository.Update(updatedEntity);

        }
    }
}
