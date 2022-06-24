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
        public async Task<IActionResult> GetAll()
        {
            var results = await _productRepository.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _productRepository.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound(id);
            }
            else
            {
                return Ok(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var addedProduct = await _productRepository.CreateAsync(product);
            return Created(string.Empty, addedProduct);//boş bırakmak yerine okunabilirlik için bu şekilde yazdık.

        }
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var checkedProduct = await _productRepository.GetByIdAsync(product.Id);
            if (checkedProduct == null)
            {
                return NotFound(product.Id);
            }
            else
            {
                await _productRepository.UpdateAsync(product);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var checkedProduct = await _productRepository.GetByIdAsync(id);
            if (checkedProduct == null)
            {
                return NotFound(id);
            }
            else
            {
                await _productRepository.RemoveAsync(id);
                return NoContent();
            }
        }

        //api/products/upload
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile formFile)
        {
            var newName = Guid.NewGuid() + "." + Path.GetExtension(formFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return Created(string.Empty, formFile);
        }

    }
}
