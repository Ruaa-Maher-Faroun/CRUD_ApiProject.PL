using CRUD_ApiProject.BLL.Services.Interfaces;
using CRUD_ApiProject.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ApiProject.PL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class BrandsController : ControllerBase
    {
  
        private readonly IBrandService brandService;

        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(brandService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var brand = brandService.GetById(id);
            if (brand is null) return NotFound();
            return Ok(brand);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BrandRequest request)
        {
            var id = brandService.Create(request);
            return CreatedAtAction(nameof(Get), new { id }, new { message = "ok" });//201 تم انشاء بنجاح with link to the new brand
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromRoute] int id,
            [FromBody] BrandRequest request)
        {
            var updated = brandService.Update(id, request);
            return updated > 0 ? Ok() : NotFound();
        }

        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var updated = brandService.ToggleStatus(id);
            return updated ? Ok(new { message = " Status toggled" }) : NotFound(new { message = "Brand not found" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var deleted = brandService.Delete(id);
            return deleted > 0 ? Ok() : NotFound();
        }



    }
}