using AutoMapper;
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;

namespace FoodDeliveryAPI;
public class MappingProfile : Profile
{
    public MappingProfile() 
    {

        CreateMap<Customer,CustomerDTO>();
        CreateMap<DeliveryPerson,DeliveryPersonDTO>();
        CreateMap<Item, ItemDTO>();
        CreateMap<Order, OrderDTO>()
            .ForMember(d => d.Customer, o => o.MapFrom(src => src.Customer))
            .ForMember(d => d.DeliveryPerson, o => o.MapFrom(src => src.DeliveryPerson))
            .ForMember(d => d.Items,o=>o.MapFrom(src=>src.Items));
        CreateMap<Restaurant, RestaurantDTO>();
        CreateMap<Restaurant, RestaurantDTOWithItem>()
            .ForMember(d => d.Items, o => o.MapFrom(src => src.Items));
        
    }
}
