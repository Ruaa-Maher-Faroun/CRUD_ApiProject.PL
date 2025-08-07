
using CRUD_ApiProject.BLL.Services;
using CRUD_ApiProject.DAL.Data;
using CRUD_ApiProject.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Scalar;
using Scalar.AspNetCore;
namespace CRUD_ApiProject.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ICategoryRepoistory, CategoryRepoistory>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
