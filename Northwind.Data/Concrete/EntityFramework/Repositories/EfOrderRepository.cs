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
    public class EfOrderRepository : EfEntityRepositoryBase<Order>, IOrderRepository
    {
        public EfOrderRepository(DbContext context) : base(context)
        {
        }
    }
}
