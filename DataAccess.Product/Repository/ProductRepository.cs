using Core.Repositories;
using DataAccess.Context;
using DataAccess.Database.Models;
using Microsoft.EntityFrameworkCore;
using AppContext = DataAccess.Context.AppContext;

namespace DataAccess.Products.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppContext _context;

        public ProductRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<Database.Models.Product> CreateProduct(int userId, string name, double price)
        {
            Product product = new Product
            {
                UserId = userId,
                Name = name,
                Price = price
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public Task <Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }


        public Task DeleteProduct(Database.Models.Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Database.Models.Product> GetAllProducts(int offset, int limit)
        {
            return _context.Products.Include(p => p.User).Skip(offset).Take(limit);
        }

        public IEnumerable<Database.Models.Product> GetAllProductsForUser(int userId, int offset, int limit)
        {
            return _context.Products.Include(p => p.User).Where(p=> p.UserId==userId).Skip(offset).Take(limit);
        }

        public async Task<Database.Models.Product?> GetById(int id)
        {
            return await _context.Products.Include(p=>p.User).SingleOrDefaultAsync(p=>p.Id==id);
        }

        
    }
}