using Azure.Core;
using CRUD_ApiProject.BLL.Services.Interfaces;
using CRUD_ApiProject.DAL.DTO.Requests;
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

        public class ProductService : GenericService<ProductRequest, ProductResponse, Product>, IProductService
        {
            private readonly IFileService _fileService;
            private readonly IProductRepository _repository;

            public ProductService(IProductRepository repository, IFileService fileService) : base(repository)
            {
                _fileService = fileService;
                _repository = repository;
            }
            public async Task<int> CreateFile(ProductRequest request)
            {
            var entity = request.Adapt<Product>();
            entity.CreatedAt = DateTime.UtcNow;
            if(request.MainImage != null)
            {
                var imagePath = await _fileService.UploadAsync(request.MainImage);
                entity.MainImage = imagePath;
            }

            return _repository.Add(entity);
        }

    }
}
