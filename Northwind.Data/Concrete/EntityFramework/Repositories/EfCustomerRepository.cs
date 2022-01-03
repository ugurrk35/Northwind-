using Microsoft.EntityFrameworkCore;
using Northwind.Data.Abstract;
using Northwind.Entities.Concrete;
using Northwind.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Concrete.EntityFramework.Repositories
{
    public class EfCustomerRepository : EfEntityRepositoryBase<Customer>, ICustomerRepository
    {
        public EfCustomerRepository(DbContext context) : base(context)
        {
        }
    }
}
