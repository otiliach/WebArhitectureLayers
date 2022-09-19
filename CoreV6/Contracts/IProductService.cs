
using DataAccess.Database.Models;

namespace Core.Contracts
{
    public interface IProductService
    {
        public Task<Product> CreateProduct(int userId, string name, double price);

        public Task<Product> UpdateProduct(int id, string name, double price);

        public Task DeleteProduct(int id);

        public Task<Product> GetProductById(int id);

        public IEnumerable<Product> GetAllProducts(int offset, int limit);

        public IEnumerable<Product> GetProductsForUser(int userId, int offset, int limit);
    }
}
