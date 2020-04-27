using AutoMapper;
using Bd.Web.App.DtoModels;
using Bd.Web.App.Models;

namespace Bd.Web.App.ModelMappers.Order
{
    public class OrderViewModelAutoMapperProfiles : Profile
    {
        public OrderViewModelAutoMapperProfiles()
        {
            CreateMap<OrderViewModel, OrderDto>().ReverseMap();
            CreateMap<OrderViewModel, OrderViewModel>().ReverseMap();
            CreateMap<OrderItemViewModel, OrderItemDto>().ReverseMap();
            CreateMap<OrderItemViewModel, OrderItemViewModel>().ReverseMap();
        }
    }
}
