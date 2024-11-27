using AutoMapper;
using VestraCare.OrderManagement.Core.Application.Interfaces.Repository;
using VestraCare.OrderManagement.Core.Application.Models;
using VestraCare.OrderManagement.Core.Application.VIewModel;

namespace VestraCare.OrderManagement.Core.Application.Interfaces.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderInfoRepository orderInfoRepository;
        private readonly IMapper mapper;

        public OrderService(IOrderInfoRepository orderInfoRepository,IMapper mapper)
        {
            this.orderInfoRepository = orderInfoRepository;
            this.mapper = mapper;
        }
        public async Task<PagignationResponseModel<OrderViewModel>> GetAllOrderAsync(OrderFilter orderFilter)
        {
            var records = await orderInfoRepository.GetAllOrderAsync(orderFilter);
            var mapedViewModelRecords= mapper.Map<List<OrderViewModel>>(records);
            int totalRecords = records.Count > 0 ? records.First().TotalRecords : 0;
            return new PagignationResponseModel<OrderViewModel>(mapedViewModelRecords, totalRecords);

        }

        public async Task<PagignationResponseModel<OrderViewModel>> GetAllOrderByFilterAsync(BaseFilter baseFilter)
        {
            var records =await orderInfoRepository.GetAllOrderByFilterAsync(baseFilter);
            var mapedViewModelRecords = mapper.Map<List<OrderViewModel>>(records);
            int totalRecords = records.Count > 0 ? records.First().TotalRecords : 0;
            return new PagignationResponseModel<OrderViewModel>(mapedViewModelRecords, totalRecords);
        }
    }
}
