using Business.Product;
using Core.Contracts;
using Core.Models;
using DataAccess.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

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
        public ActionResult<IEnumerable<Product>> 
            GetAllProducts([Range(0,int.MaxValue)] int offset=0, [Range(0, 100)] int limit = 20)
        {
            var products = _productService.GetAllProducts(offset,limit);
            return Ok(products.Select(p=> new ProductForList(p)));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Product>> CreateProduct([Required][FromForm] string name,
            [FromForm][Range(1,double.MaxValue)] double price)
        {
            string userIdSting= User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            int userId = int.Parse(userIdSting);

            var createdProduct=await _productService.CreateProduct(userId, name, price);
            return Ok(new ProductForList(createdProduct));
        }
    }
}
