using ChannelEngine.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngine.Core.Interface
{
    public interface IOrderService
    {
        Task<List<OrderModel>> GetOrdersInProgressAsync();
        List<OrderModel> GetTopOrdersInProgress(List<OrderModel> ordersInProgress, int top);
    }
}
