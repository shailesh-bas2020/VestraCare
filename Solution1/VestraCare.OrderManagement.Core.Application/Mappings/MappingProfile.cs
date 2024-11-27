using AutoMapper;
using VestraCare.OrderManagement.Core.Domain.Entities;

namespace VestraCare.OrderManagement.Core.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderDetailEntity, OrderViewModel>();
        }
    }
}
