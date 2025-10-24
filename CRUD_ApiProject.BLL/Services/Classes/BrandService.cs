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

        public class BrandService : GenericService<BrandRequest, BrandResponse, Brand>, IBrandService
        {
        private readonly IFileService _fileService;
        private readonly IBrandRepository _iBrandRepository;

        public BrandService(IBrandRepository iBrandRepository, IFileService fileService) : base(iBrandRepository)
            {
                _fileService = fileService;
                _iBrandRepository = iBrandRepository;
            }
        public async Task<int> CreateFile(BrandRequest request)
        {
            var entity = request.Adapt<Brand>();
            entity.CreatedAt = DateTime.UtcNow;
            if (request.MainImage != null)
            {
                var imagePath = await _fileService.UploadAsync(request.MainImage, "brandsImgs");
                entity.MainImage = imagePath;
            }

            return _iBrandRepository.Add(entity);
        }



        public async Task<int> UpdateFile(BrandRequest request, int id)
        {
            var entity = _iBrandRepository.GetById(id);
            var fileName = entity.MainImage;
            if (entity is null) return 0;
            if (request.MainImage != null && entity.MainImage != null)
            {
                await _fileService.UpdateAsync(request.MainImage, fileName, "brandsImgs");

            }
            var updatedEntity = request.Adapt(entity);
            entity.MainImage = fileName;
            return _iBrandRepository.Update(updatedEntity);
        }

        public async Task<int> DeleteFile(int id)
        {
            var entity = _iBrandRepository.GetById(id);
            if (entity is null) return 0;
            await _fileService.DeleteAsync(entity.MainImage, "brandsImgs");
            return _iBrandRepository.Remove(entity);
        }

    }
    }
