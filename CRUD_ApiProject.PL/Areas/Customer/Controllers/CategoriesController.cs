using CRUD_ApiProject.BLL.Services.Interfaces;
using CRUD_ApiProject.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ApiProject.PL.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(categoryService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var category = categoryService.GetById(id);
            if (category is null) return NotFound();
            return Ok(category);
        }

        


    }
}
