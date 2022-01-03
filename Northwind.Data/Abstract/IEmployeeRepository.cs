using Northwind.Entities.Concrete;
using Northwind.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Abstract
{
    public interface IEmployeeRepository:IEntityRepository<Employee>
    {
    }
}
