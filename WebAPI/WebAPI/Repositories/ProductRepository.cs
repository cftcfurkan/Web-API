using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interfaces;

namespace WebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
