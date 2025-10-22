using CRUD_ApiProject.BLL.Services.Interfaces;
using CRUD_ApiProject.DAL.DTO.Requests;
using CRUD_ApiProject.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ApiProject.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService) {
            this.categoryService = categoryService;
        }
        [HttpGet("")]
        public IActionResult GetAll() {
            return Ok(categoryService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id) {
            var category = categoryService.GetById(id);
            if(category is null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryRequest request)
        {
            var id = categoryService.Create(request);
            return CreatedAtAction(nameof(Get), new { id }, new {message="ok"});//201 تم انشاء بنجاح with link to the new category
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id,
            [FromBody] CategoryRequest request) { 
            var updated = categoryService.Update(id, request);
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
            var deleted = categoryService.Delete(id);
            return deleted > 0 ? Ok() : NotFound();
        }




    }
}
