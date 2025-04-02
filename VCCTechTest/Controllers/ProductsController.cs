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
            new Product { Id = 1, Name = "Product A", CurrentPrice = 100.0M, LastUpdated = DateTime.Parse("2024-09-26T12:34:56") },
            new Product { Id = 2, Name = "Product B", CurrentPrice = 200.0M, LastUpdated = DateTime.Parse("2024-09-26T12:34:56") }
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
        }

        // api/products/{id}
        [HttpGet("GetProduct/{id:int}")]
        public Product GetProduct(int id)
        {
            return Products.SingleOrDefault(x => x.Id == id)!;

            //price history
        }

        // api/products/{id}/apply-discount
        [HttpPost("{id}/ApplyDiscount")]
        public Product ApplyDiscount(int id, [FromBody] Decimal discountPercentage)
        {
            Product product = Products.SingleOrDefault(x => x.Id == id)!;

            Decimal oldPrice = product.CurrentPrice;
            Decimal newPrice = product.CurrentPrice * (1 - (discountPercentage / 100));

            product.CurrentPrice = newPrice;
            product.LastUpdated = DateTime.Now;

            return Products.SingleOrDefault(x => x.Id == id)!;
            //return CreatedAtAction(nameof(product), product, new { discountedPrice = newPrice.ToString() });
        }

        // api/products/{id}/update-price
        [HttpPut("{id}/UpdatePrice")]
        public Product UpdatePrice(int id, [FromBody] Decimal newPrice)
        {
            Product product = Products.SingleOrDefault(x => x.Id == id)!;

            product.CurrentPrice = newPrice;
            product.LastUpdated = DateTime.UtcNow;

            return Products.SingleOrDefault(x => x.Id == id)!;
        }
    }
}
