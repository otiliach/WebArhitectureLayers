using Core.Contracts;
using Core.Repositories;

namespace Business.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DataAccess.Database.Models.Product> CreateProduct(int userId, string name, double price)
        {
            var createdProduct= await _productRepository.CreateProduct(userId, name, price);
            return await _productRepository.GetById( createdProduct.Id);
        }

        public async Task DeleteProduct(int id)
        {
            var product =await _productRepository.GetById(id);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }
            await _productRepository.DeleteProduct(product);
        }

        public IEnumerable<DataAccess.Database.Models.Product> GetAllProducts(int offset, int limit)
        {
            return _productRepository.GetAllProducts(offset, limit);
        }

        public async Task<DataAccess.Database.Models.Product> GetProductById(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                throw new InvalidOperationException("Product not found");
            }
            return product;
        }

        public IEnumerable<DataAccess.Database.Models.Product> GetProductsForUser(int userId, int offset, int limit)
        {
            return _productRepository.GetAllProductsForUser(userId, offset, limit);
        }

        public async Task<DataAccess.Database.Models.Product> UpdateProduct(int id, string name, double price)
        {
            var product =await _productRepository.GetById(id);
            
            if(product == null)
            {
                throw new InvalidOperationException("Product not found");
            }
            product.Name = name;
            product.Price = price;
            var updatedProduct= await _productRepository.UpdateProduct(product);
            return updatedProduct;
        }
    }
}