using AutoMapper;
using SampleProject.Application.Features.Orders.Commands;
using SampleProject.Application.ViewModels;
using SampleProject.Core.Entities;

namespace SampleProject.Application.Mappers;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderResponse>().ReverseMap();
        CreateMap<Order, CreateOrderCommand>().ReverseMap();
        CreateMap<Order, UpdateOrderCommand>().ReverseMap();   
    }
}