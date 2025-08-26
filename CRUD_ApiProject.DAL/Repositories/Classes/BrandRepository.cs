using CRUD_ApiProject.DAL.Data;
using CRUD_ApiProject.DAL.Models;
using CRUD_ApiProject.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ApiProject.DAL.Repositories.Classes
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context) { }
}
}
