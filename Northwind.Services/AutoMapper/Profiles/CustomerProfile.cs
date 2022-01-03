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
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
          CreateMap<CustomerAddDto,Customer>();
            CreateMap<CustomerUpdateDto,Customer>();
        }
    }
}
