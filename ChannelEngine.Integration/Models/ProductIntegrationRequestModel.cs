using System.Collections.Generic;

namespace ChannelEngine.Integration.Models
{
    public class ProductIntegrationRequestModel
    {
        public string MerchantProductNo { get; set; }
        public List<ProductStockLocation> StockLocations { get; set; }
    }

    public class ProductStockLocation
    {
        public int Stock { get; set; }
        public int StockLocationId { get; set; }
    }
}
