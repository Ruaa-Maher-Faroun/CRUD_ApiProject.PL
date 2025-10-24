using CRUD_ApiProject.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ApiProject.PL.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll(true));
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var product = _productService.GetById(id);
            if (product is null) return NotFound();
            return Ok(product);
        }

    }
}
