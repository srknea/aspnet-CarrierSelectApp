using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistance.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /*
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }
        */

        /*
        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDate = DateTime.Now, Stock = 10},
                new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreatedDate = DateTime.Now, Stock = 20},
                new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 300, CreatedDate = DateTime.Now, Stock = 30},
            });

            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
        */

    }
}
