using CRUD_ApiProject.BLL.Services;
using CRUD_ApiProject.DAL.DTO.Requests;
using CRUD_ApiProject.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ApiProject.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService) {
            this.categoryService = categoryService;
        }
        [HttpGet("")]
        public IActionResult GetAll() {
            return Ok(categoryService.GetAllCategories());
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id) {
            var category = categoryService.GetCategoryById(id);
            if(category is null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryRequest request)
        {
            var id = categoryService.CreateCategory(request);
            return CreatedAtAction(nameof(Get), new { id });//201 تم انشاء بنجاح with link to the new category
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id,
            [FromBody] CategoryRequest request) { 
            var updated = categoryService.UpdateCategory(id, request);
            return updated > 0 ? Ok() : NotFound();
        }

        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var updated = categoryService.ToggleStatus(id);
            return updated ? Ok(new { message=" Status toggled" }): NotFound(new { message="Category not found" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id) { 
            var deleted = categoryService.DeleteCategory(id);
            return deleted > 0 ? Ok() : NotFound();
        }




    }
}
