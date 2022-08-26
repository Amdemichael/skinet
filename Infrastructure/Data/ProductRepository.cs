using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            var products = await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .ToListAsync();            
            return products;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductBrandsAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductTypesAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }
    }
}