using ChannelEngine.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChannelEngine.Core.Interface
{
    public interface IProductService
    {
        Task<bool> UpdateProductStockAsync(int quantity, int stockLocationId, string merchantNumber);
    }
}
