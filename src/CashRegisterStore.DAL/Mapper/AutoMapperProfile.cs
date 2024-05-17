using AutoMapper;
using CashRegisterStore.DAL.Data.Entities;
using CashRegisterStore.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CashRegisterStore.DAL.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BasketProductDto, BasketProduct>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderProductDto, OrderProduct>().ReverseMap();
            CreateMap<PhotoDto, Photo>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<SubcategoryDto, Subcategory>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
        
    }

    
}
