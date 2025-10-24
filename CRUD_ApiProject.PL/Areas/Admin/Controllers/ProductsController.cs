using CRUD_ApiProject.BLL.Services.Classes;
using CRUD_ApiProject.BLL.Services.Interfaces;
using CRUD_ApiProject.DAL.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CRUD_ApiProject.PL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        //[HttpGet("")]
        //public IActionResult GetAll()
        //{
        //    return Ok(_productService.GetAll());
        //}
        //[HttpGet("{id}")]
        //public IActionResult Get([FromRoute] int id)
        //{
        //    var brand = _productService.GetById(id);
        //    if (brand is null) return NotFound();
        //    return Ok(brand);
        //}

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] ProductRequest request)
        {
            
            var result = await _productService.CreateFile(request);
            return Ok(result);
        }

        //[HttpPatch("{id}")]
        //public IActionResult Update([FromRoute] int id,
        //    [FromBody] ProductRequest request)
        //{
        //    var updated = _productService.Update(id, request);
        //    return updated > 0 ? Ok() : NotFound();
        //}

        //[HttpPatch("ToggleStatus/{id}")]
        //public IActionResult ToggleStatus([FromRoute] int id)
        //{
        //    var updated = _productService.ToggleStatus(id);
        //    return updated ? Ok(new { message = " Status toggled" }) : NotFound(new { message = "Brand not found" });
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete([FromRoute] int id)
        //{
        //    var deleted = _productService.Delete(id);
        //    return deleted > 0 ? Ok() : NotFound();
        //}



    }
}