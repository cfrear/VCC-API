using Microsoft.AspNetCore.Mvc;
using VCCTechTest.Models;

namespace VCCTechTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly Product[] Products =
        [
            new Product { Id = 1, Name = "Product A", CurrentPrice = 100.0, LastUpdated = DateTime.Parse("2024-09-26T12:34:56") },
            new Product { Id = 2, Name = "Product B", CurrentPrice = 200.0, LastUpdated = DateTime.Parse("2024-09-26T12:34:56") }
        ];

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        // api/products/
        [HttpGet("GetProducts")]
        public IEnumerable<Product> GetProducts()
        {

            return Products;

            //return Enumerable.Range(0, Products.Count()).Select(index => new Product
            //{
            //    Id = Products[index].Id,
            //    Name = Products[index].Name,
            //    CurrentPrice = Products[index].CurrentPrice,
            //    LastUpdated = Products[index].LastUpdated
            //})
            //.ToArray();
        }

        // api/products/{id}
        [HttpGet("GetProduct/{id:int}")]
        public Product GetProduct(int id)
        {
            return Products.SingleOrDefault(x => x.Id == id)!;
        }

        // api/products/{id}/apply-discount
        [HttpPost("{id}/ApplyDiscount")]
        public ActionResult<Product> ApplyDiscount(int id, [FromBody] double discountPercentage)
        {
            Product product = Products.SingleOrDefault(x => x.Id == id)!;
            Double oldPrice = product.CurrentPrice;
            Double newPrice = product.CurrentPrice * (discountPercentage / 100);

            product.CurrentPrice = newPrice;

            return CreatedAtAction(nameof(product), product, new { discountedPrice = newPrice.ToString() });
        }

        // api/products/{id}/update-price
        [HttpPut("{id}/UpdatePrice")]
        public ActionResult<Product> UpdatePrice(int id, [FromBody] double newPrice)
        {
            Product product = Products.SingleOrDefault(x => x.Id == id)!;

            product.CurrentPrice = newPrice;
            product.LastUpdated = DateTime.UtcNow;

            return Products.SingleOrDefault(x => x.Id == id)!;
        }
    }
}
