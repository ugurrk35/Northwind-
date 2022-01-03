using Microsoft.Extensions.DependencyInjection;
using Northwind.Data.Abstract;
using Northwind.Data.Concrete;
using Northwind.Data.Concrete.EntityFramework.Context;
using Northwind.Services.Abstract;
using Northwind.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices ( this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<NorthwindContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryServices, CategoryManager>();
            serviceCollection.AddScoped<IProductService, ProductManager>();
           return serviceCollection;
        }
      
    }
}
