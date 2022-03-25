using ChannelEngine.Core.Interface;
using ChannelEngine.Integration.Models;
using ChannelEngine.Shared.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChannelEngine.Integration.MerchantAPI
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppConfiguration _appConfiguration;

        public ProductService(IHttpClientFactory httpClientFactory, IOptions<AppConfiguration> appConfiguration)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("channelengineapi");
            _appConfiguration = appConfiguration.Value;
        }

        public async Task<bool> UpdateProductStockAsync(int quantity, int stockLocationId, string merchantNumber)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"/v2/offer/stock?apikey={_appConfiguration.ChannelEngineAPIKey}")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                new ProductIntegrationRequestModel
                {
                    MerchantProductNo = merchantNumber,
                    StockLocations = new System.Collections.Generic.List<ProductStockLocation>
                     {
                         new ProductStockLocation
                         {
                             Stock = quantity,
                             StockLocationId = stockLocationId
                         }
                     }
                }))
            };
            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
}
