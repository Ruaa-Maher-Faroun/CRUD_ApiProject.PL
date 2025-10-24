using CRUD_ApiProject.BLL.Services.Classes;
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
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> Create([FromForm] BrandRequest request)
        {
            var id = await brandService.CreateFile(request);
            return CreatedAtAction(nameof(Get), new { id }, new { message = "ok" });//201 تم انشاء بنجاح with link to the new brand
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,
            [FromForm] BrandRequest request)
        {
            var updated = await brandService.UpdateFile(request, id);

            return updated > 0 ? Ok() : NotFound();
        }

        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus([FromRoute] int id)
        {
            var updated = brandService.ToggleStatus(id);
            return updated ? Ok(new { message = " Status toggled" }) : NotFound(new { message = "Brand not found" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await brandService.DeleteFile(id);


            return deleted > 0 ? Ok() : NotFound();
        }



    }
}