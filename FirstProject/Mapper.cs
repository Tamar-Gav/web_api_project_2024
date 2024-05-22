using AutoMapper;
using Entities;
using DTOs;
using Entities.product;
using Microsoft.AspNetCore.Mvc;
namespace FirstProject;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<OrderItemDto, OrderItem>();
        CreateMap<CreateOrderDTO, Order>()
            .ForMember(dest => dest.OrderItems,
             opts => opts.MapFrom(src => src.OrderItemDTOs))

            .ForMember(dest => dest.OrderDate,
             opts => opts.MapFrom(opts => DateOnly.FromDateTime(DateTime.UtcNow)));

            CreateMap<Product, ProductDto>().ForMember(dest => dest.CategoryName,
            opts => opts.MapFrom(src => src.Category.CategoryName));
        
    }
    
}
