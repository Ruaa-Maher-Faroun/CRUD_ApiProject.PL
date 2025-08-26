using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_ApiProject.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_ApiProject.DAL.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands{ get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }
}
