namespace VCCTechTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal CurrentPrice { get; set; }

        //PriceHistory

        public DateTime LastUpdated { get; set; }
    }
}
