using Business.Product;
using Core.Contracts;
using Core.Models;
using DataAccess.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController:ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts([Range(0,int.MaxValue)] int offset=0, [Range(0, 100)] int limit = 20)
        {
            var products = _productService.GetAllProducts(offset,limit);
            return Ok(products.Select(p=> new ProductForList(p)));
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([Required][FromForm] string name,
            [FromForm][Range(1,double.MaxValue)] double price)
        {
            var createdProduct=await _productService.CreateProduct(1, name, price);
            return Ok(new ProductForList(createdProduct));
        }
    }
}
