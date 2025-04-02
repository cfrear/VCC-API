using Microsoft.AspNetCore.Mvc;
using VCCTechTest.Models;

namespace VCCTechTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly Product[] Products = new[]
        {
            new Product { Id = 1, Name = "Product A", CurrentPrice = 100.0, LastUpdated = DateTime.Parse("2024-09-26T12:34:56") },
            new Product { Id = 2, Name = "Product B", CurrentPrice = 200.0, LastUpdated = DateTime.Parse("2024-09-26T12:34:56") },
            new Product { Id = 2, Name = "Product C", CurrentPrice = 25.50, LastUpdated = DateTime.Parse("2024-09-26T12:34:56") }
        };

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return Products;

            //return Enumerable.Range(1, 5).Select(index => new Product
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
