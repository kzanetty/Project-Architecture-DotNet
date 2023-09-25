using Microsoft.AspNetCore.Mvc;
using ProjectArchitecture.Application.DTOs;
using ProjectArchitecture.Application.Interfaces;
using ProjectArchitecture.Application.Requests;

/*
 * Tratamento de erros
 * Status code
 * Autorização e autenticação
 * Especificar retornos corretamente
 */
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
        public async Task<ActionResult<IEnumerable<IActionResult>>> GetProducts()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _productService.GetProductById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            await _productService.Add(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
        {
            await _productService.Update(request);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productService.Remove(id);
            return Ok();
        }
    }
}
