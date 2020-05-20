using AutoMapper;
using Bd.Web.App.DtoModels;
using Bd.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.App.ModelMappers.OrderHistory
{
    public class OrderHistoryViewModelAutoMapperProfiles : Profile
    {
        public OrderHistoryViewModelAutoMapperProfiles()
        {
            CreateMap<OrderHistoryDto, OrderHistoryViewModel>().ReverseMap();
            CreateMap<OrderViewModel, OrderHistoryViewModel>();
            CreateMap<OrderViewModel, OrderHistoryDto>();

            CreateMap<OrderItemViewModel, OrderItemHistoryViewModel>().ReverseMap();
            CreateMap<OrderItemViewModel, OrderItemHistoryViewModel>().ReverseMap();
            CreateMap<OrderItemViewModel, OrderItemHistoryDto>().ReverseMap();
            //CreateMap<OrderItemViewModel, OrderItemHistoryViewModel>().ReverseMap();
        }
    }
}
