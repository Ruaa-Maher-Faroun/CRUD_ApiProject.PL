using CRUD_ApiProject.DAL.Data;
using CRUD_ApiProject.DAL.Data.Migrations;
using CRUD_ApiProject.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CRUD_ApiProject.DAL.Utils
{
    public class SeedData: ISeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedData(
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;

        }

        public async Task DataSeedingAsync()
        {
            if ((await _context.Database.GetPendingMigrationsAsync()).Any())
            {
                await _context.Database.MigrateAsync();
            }
            if(!await _context.Categories.AnyAsync())
            {
                await _context.Categories.AddRangeAsync(
                    new Category { Name = "Clothes" },
                    new Category { Name = "Mobile" }
                    );

                
            }

            if (!await _context.Brands.AnyAsync())
            {
                await _context.Brands.AddRangeAsync(
                    new Brand { Name = "Samsung" },
                    new Brand { Name = "Apple" },
                    new Brand { Name = "Nike" }
                    );
            }
            await _context.SaveChangesAsync();
        }


        public async Task IdentityDataSeedingAsync()
        {
            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }
            if (!await _userManager.Users.AnyAsync())
            {
              
                var user2 = new ApplicationUser()
                {
                    Email = "Ruaafaroun2@gmail.com",
                    FullName = "Ruaa Faroun2",
                    PhoneNumber = "0594264866",
                    UserName = "RoRo2",
                    EmailConfirmed = true
                };
                var user3 = new ApplicationUser()
                {
                    Email = "Ruaafaroun3@gmail.com",
                    FullName = "Ruaa Faroun3",
                    PhoneNumber = "0594264877",
                    UserName = "RoRo3",
                    EmailConfirmed = true
                };

                var user4 = new ApplicationUser()
                {
                    Email = "Ruaafaroun@gmail.com",
                    FullName = "Ruaa Faroun3",
                    PhoneNumber = "0594264877",
                    UserName = "RoRo3",
                    EmailConfirmed = true
                };

                await _userManager.CreateAsync(user4,"Pass@121212");
                await _userManager.CreateAsync(user2, "Pass@121212");
                await _userManager.CreateAsync(user3, "Pass@121212");
                await _userManager.AddToRoleAsync(user4, "Admin");
                await _userManager.AddToRoleAsync(user2, "Customer");
                await _userManager.AddToRoleAsync(user3, "SuperAdmin");
                await _context.SaveChangesAsync();


                //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                //    await _roleManager.CreateAsync(new IdentityRole("Customer"));
                //    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }

        }

    }
}
