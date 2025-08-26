using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_ApiProject.DAL.Data;
using CRUD_ApiProject.DAL.Models;
using CRUD_ApiProject.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD_ApiProject.DAL.Repositories.Classes
{
    public class CategoryRepoistory :GenericRepository<Category>,ICategoryRepoistory
    {
        public CategoryRepoistory(ApplicationDbContext context):base(context){        }
    }
}
