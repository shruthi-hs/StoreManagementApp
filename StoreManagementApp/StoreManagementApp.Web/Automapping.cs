using AutoMapper;
using StoreManagementApp.DTO;
using StoreManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementApp
{
    public class Automapping : Profile
    {
        public Automapping()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Stock, StockDTO>().ReverseMap();
            CreateMap<Staff, StaffDTO>().ReverseMap();
        }
    }
}
