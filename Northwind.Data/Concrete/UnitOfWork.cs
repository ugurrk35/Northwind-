using Northwind.Data.Abstract;
using Northwind.Data.Concrete.EntityFramework.Context;
using Northwind.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NorthwindContext _context;
        private EfCustomerRepository _customerRepository;
        private EfEmployeeRepository _employeeRepository;
        private EfOrderRepository _orderRepository;
        private EfProductRepository _productRepository;
        private EfCategoryRepository _categoryRepository;

        public UnitOfWork(NorthwindContext context)
        {
            _context = context;
        }

        public ICustomerRepository Customers => _customerRepository ?? new EfCustomerRepository(_context);
            //?? değişkenin değerinin null durumunda altarnatif
        public IEmployeeRepository Employees => _employeeRepository ?? new EfEmployeeRepository(_context);

        public IOrderRepository Orders => _orderRepository ?? new EfOrderRepository(_context);

        public IProductRepository Products => _productRepository ?? new EfProductRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();//save changes metodu integer değer
        }
    }
}
