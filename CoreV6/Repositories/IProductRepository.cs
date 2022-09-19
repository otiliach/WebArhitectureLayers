
namespace Core.Repositories
{
    using DataAccess.Database.Models;

    public interface IProductRepository
    {
        Task<Product> CreateProduct(int userId, string name, double price);

        Task<Product> UpdateProduct(Product product);

        Task DeleteProduct(Product product);

        Task<Product?> GetById(int id);

        IEnumerable<Product> GetAllProducts(int offset, int limit);

        IEnumerable<Product> GetAllProductsForUser(int userId, int offset, int limit);

    }
}
