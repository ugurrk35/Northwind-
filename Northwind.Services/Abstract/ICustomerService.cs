using Northwind.Entities.Concrete;
using Northwind.Entities.Dtos;
using Northwind.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstract
{
    public interface ICustomerService
    {

        Task<IDataResult<Customer>> Get(string customerId);
        Task<IDataResult<IList<Customer>>> GetAll();
        Task<IDataResult<IList<Customer>>> GetAllByNonDeleted();
        Task<IResult> Add(CustomerAddDto customerAddDto);
        Task<IResult> Update(CustomerUpdateDto customerUpdateDto);
        Task<IResult> HardDelete(int customerId);
        Task<IResult>  Delete(int customerId);
    }
}
