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
            public BrandService(IBrandRepository iBrandRepository) : base(iBrandRepository)
            {
            }

        }
    }
