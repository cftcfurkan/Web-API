using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{

    [EnableCors]
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
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _productRepository.GetAllAsync();
            return Ok(results);
        }

        //api/products/1   => [FromRoute] demek default olarak gelir.
        //api/products?id=1 => [FromQuery] olarak belirtirsek 
        [Authorize(Roles = "Admin")]

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
        // bir metod HttpPost'sa ve bir parametre alıyorsa aslında default olarak [FromBody] vardır.
        //[FromQuery] yazarsak  post api/products?id=1&name=telefon&... olarak yazmamız gerekirdi.
        [HttpPost]
        public async Task<IActionResult> Create(/*[FromBody]*/Product product)
        {
            var addedProduct = await _productRepository.CreateAsync(product);
            return Created(string.Empty, addedProduct);//boş bırakmak yerine okunabilirlik için bu şekilde yazdık.

        }
        // defaultu [FromBody]
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
        //Defaultu [FromRoute] query ile de alabiliriz ancak ozaman resti bozmuş oluruz.
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
        [HttpGet("[action]")]
        /*[FromForm] string name, [FromHeader] string auth, */
        public IActionResult Test([FromServices] IDummyRepository dummyRepository)
        {
            //request => response
            // header,body

            //var authentication = HttpContext.Request.Headers["auth"];
            //var name2 = HttpContext.Request.Form["name"];
            return Ok(dummyRepository.GetName()); // dependency injection için ctor içine yazmak zorunda değiliz,[FromService] ile de kullanabiliriz.
        }

    }
}
