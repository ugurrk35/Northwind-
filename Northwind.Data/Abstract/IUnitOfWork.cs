using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        ICustomerRepository Customers { get; } //unitofwork.customers
        IEmployeeRepository Employees { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }

        Task<int> SaveAsync();                 //etkilenen kayt sayısını almak için int
        //_unitOfWork.SaveAsync();

    }
}
