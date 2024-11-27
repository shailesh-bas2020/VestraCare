using Dapper;
using VestraCare.OrderManagement.Core.Application.Interfaces.Repository;
using VestraCare.OrderManagement.Core.Application.Models;
using VestraCare.OrderManagement.Core.Domain.Constants.Queries;
using VestraCare.OrderManagement.Core.Domain.Entities;
namespace VestraCare.OrderManagement.Infrastructure.Persistence.Repository
{
    public class OrderInfoRepository : IOrderInfoRepository
    {
        private readonly ISqlDbContext _sqlDbContext;
        public OrderInfoRepository(ISqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
        }
        public async Task<IList<OrderDetailEntity>> GetAllOrderAsync(OrderFilter orderFilter)
        {
            var para = new DynamicParameters();
            para.Add("@CustomerId", orderFilter.CustomerId);
            para.Add("@FromDate", orderFilter.FromDate);
            para.Add("@ToDate", orderFilter.ToDate);
            para.Add("@PageSize", orderFilter.PageSize);
            para.Add("@PageNumber", orderFilter.PageNumber);
            var lstOrder = await _sqlDbContext.GetAllAsync<OrderDetailEntity>(OrderQueries.AllOrder, para);
            return lstOrder.ToList();
        }
        public async Task<IList<OrderDetailEntity>> GetAllOrderByFilterAsync(BaseFilter baseFilter)
        {
            var para = new DynamicParameters(); 
            para.Add("@PageSize", baseFilter.PageSize);
            para.Add("@PageNumber", baseFilter.PageNumber);
            var lstOrder = await _sqlDbContext.GetAllAsync<OrderDetailEntity>(OrderQueries.AllOrder, para);
            return lstOrder.ToList();
        }
    }
}
