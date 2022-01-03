using AutoMapper;
using Northwind.Entities.Concrete;
using Northwind.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>();

            CreateMap<CategoryUpdateDto, Category>();
               
            CreateMap<Category, CategoryUpdateDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryAddDto>();
        }
    }
}
