using ETicaretAPI.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productservice;

        public ProductsController(IProductService productservice)
        {
            _productservice = productservice;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productservice.GetProducts();
            return Ok(products);
        }
    }
}
