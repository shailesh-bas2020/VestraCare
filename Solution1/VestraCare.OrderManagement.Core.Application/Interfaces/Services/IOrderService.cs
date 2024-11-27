using VestraCare.OrderManagement.Core.Application.Models;
using VestraCare.OrderManagement.Core.Application.VIewModel;

namespace VestraCare.OrderManagement.Core.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<PagignationResponseModel<OrderViewModel>> GetAllOrderAsync(OrderFilter orderFilter);
        Task<PagignationResponseModel<OrderViewModel>> GetAllOrderByFilterAsync(BaseFilter baseFilter);
    }
}
