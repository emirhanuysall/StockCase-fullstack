namespace Backend.DTO
{
    public class StockDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}

