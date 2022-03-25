namespace ChannelEngine.Shared.Models
{
    public class OrderModel
    {
        public string ProductName { get; set; }
        public string GTIN { get; set; }
        public int TotalQuantity { get; set; }
        public string MerchantProductNo { get; set; }
        public int? StockLocationId { get; set; }
    }
}
