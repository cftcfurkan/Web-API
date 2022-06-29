using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ProductContext _context;
        public CategoriesController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/products")]
        public IActionResult GetWithProducts(int id)
        {
            // kategoriye productları ekleme.
            var data = _context.Categories.Include(x => x.Products).SingleOrDefault(x => x.Id == id);
            if (data == null)
            {
                return NotFound(id);
            }

            return Ok(data);

            // 500 : Error : Internal Server Error hatası verdi bu hatayı düzeltmek için Microsoft.AspNetCore.Mvc.NewtonsoftJson paketini yüklememiz ve program.cs AddControllers alanına + .AddNewtonsoftJson(opt =>
            //{
            //    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //}); yazmamız gerekiyor.
        }
        

    }
}
