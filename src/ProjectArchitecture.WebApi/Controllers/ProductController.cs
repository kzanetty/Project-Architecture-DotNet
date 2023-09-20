using Microsoft.AspNetCore.Mvc;
using ProjectArchitecture.Application.Interfaces;

namespace ProjectArchitecture.WebApi.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }
    }
}
