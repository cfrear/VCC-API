namespace VCCTechTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CurrentPrice { get; set; }

        //PriceHistory

        public DateTime LastUpdated { get; set; }
    }
}
