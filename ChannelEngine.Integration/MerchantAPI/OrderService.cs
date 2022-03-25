using ChannelEngine.Core.Interface;
using ChannelEngine.Integration.Models;
using ChannelEngine.Shared.Enums;
using ChannelEngine.Shared.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChannelEngine.Integration.MerchantAPI
{
    public class OrderService : IOrderService
    {

        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AppConfiguration _appConfiguration;

        public OrderService(IHttpClientFactory httpClientFactory, IOptions<AppConfiguration> appConfiguration)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("channelengineapi");
            _appConfiguration = appConfiguration.Value;
        }

        public async Task<List<OrderModel>> GetOrdersInProgressAsync()
        {
            var results = new List<OrderModel>();
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"/api/v2/orders?statuses={OrderStatusEnum.IN_PROGRESS}&apikey={_appConfiguration.ChannelEngineAPIKey}"));
            if (response.IsSuccessStatusCode)
            {
                var responsePayload = JsonConvert.DeserializeObject<OrderIntegrationModel>(await response.Content.ReadAsStringAsync());
                responsePayload.Content.ForEach(x => x.Lines.ForEach(y => 
                {
                    results.Add(new OrderModel
                    {
                        GTIN = y.Gtin,
                        ProductName = y.Description,
                        TotalQuantity = y.Quantity, 
                        StockLocationId = y.StockLocation?.Id,
                        MerchantProductNo = y.MerchantProductNo,
                    });
                }));
            }

            return results;
        }


        public List<OrderModel> GetTopOrdersInProgress(List<OrderModel> ordersInProgress, int top)
        {
            return ordersInProgress.OrderByDescending(x => x.TotalQuantity).Take(top).ToList();
        }
    }
}
