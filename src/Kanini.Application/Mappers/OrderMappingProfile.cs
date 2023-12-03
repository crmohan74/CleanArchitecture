using AutoMapper;
using Kanini.Application.Features.Orders.Commands;
using Kanini.Application.ViewModels;
using Kanini.Core.Entities;

namespace Kanini.Application.Mappers;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderResponse>().ReverseMap();
        CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
        CreateMap<Order, UpdateOrderCommand>().ReverseMap();   
    }
}