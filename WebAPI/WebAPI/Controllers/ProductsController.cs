using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    return Ok(new[] { new { Name = "Bilgisayar", Price = 2000 }, new { Name = "Telefon", Price = 1500 } });

        //}

        //[HttpGet("{id}")]
        //public IActionResult GetProduct(int id)
        //{
        //    return Ok(new[] { new { Name = "Bilgisayar", Price = 2000 } });

        //}

        [HttpGet]
        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetById(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    }
}
