namespace VCCTechTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal CurrentPrice { get; set; }

        //PriceHistory

        public DateTime LastUpdated { get; set; }
    }
}
