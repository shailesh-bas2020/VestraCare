using VestraCare.OrderManagement.Core.Application.Models;
using VestraCare.OrderManagement.Core.Domain.Entities;

namespace VestraCare.OrderManagement.Core.Application.Interfaces.Repository
{
    public interface IOrderInfoRepository
    {
        Task<IList<OrderDetailEntity>> GetAllOrderAsync(OrderFilter orderFilter);
        Task<IList<OrderDetailEntity>> GetAllOrderByFilterAsync(BaseFilter baseFilter);
    }
}
