using VCCTechTest.Controllers;
using VCCTechTest.Models;

namespace UnitTests
{
    [TestFixture]
    public class ProductsController_Should
    {
        private ProductsController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new ProductsController();
        }

        [Test]
        public void UpdatePrice_Normal()
        {
            var result = _controller.UpdatePrice(1, 300.0M);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.CurrentPrice, Is.EqualTo(300.0M));
        }

        [Test]
        public void ApplyDiscount_Normal()
        {
            var result = _controller.ApplyDiscount(2, 10);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.CurrentPrice, Is.EqualTo(180.0M));
        }
    }
}
