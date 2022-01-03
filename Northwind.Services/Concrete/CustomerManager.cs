using Northwind.Data.Abstract;
using Northwind.Entities.Concrete;
using Northwind.Entities.Dtos;
using Northwind.Services.Abstract;
using Northwind.Shared.Utilities.Results.Abstract;
using Northwind.Shared.Utilities.Results.ComplexTypes;
using Northwind.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> Add(CustomerAddDto customerAddDto)
        {
            await _unitOfWork.Customers.AddAsync(new Customer
            {
                CompanyName = customerAddDto.CompanyName,
                ContactName = customerAddDto.ContactName,
                ContactTitle = customerAddDto.ContactTitle,
                Address = customerAddDto.Address,
                City = customerAddDto.City,
                PostalCode = customerAddDto.PostalCode,
                Country = customerAddDto.Country,
                Phone = customerAddDto.Phone,
                Region = customerAddDto.Region,
                Fax = customerAddDto.Fax

            }); // ContinueWith(t=>_unitOfWork.SaveAsync());
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success,$"{customerAddDto.CompanyName}adlı müşteri başarıyla eklenmiştir");
        }

        public async Task<IResult> Delete(int customerId)
        {
            var customer = await _unitOfWork.Customers.GetAsync(c => c.CustomerId == "customerId");
            if (customer!=null)
            {
                await _unitOfWork.Customers.UpdateAsync(customer);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{customer.CompanyName}adlı müşteri başarıyla silinmiştir");
            }
            return new Result(ResultStatus.Error, "Böyle bir müşteri bulunamadı", null);
        }

        public async Task<IDataResult<Customer>> Get(string customerId)
        {
            
           var customer =await _unitOfWork.Customers.GetAsync(c=>c.CustomerId == "customerId",c=>c.Orders);
           if(customer != null)
            {
                return new DataResult<Customer>(ResultStatus.Success,customer);
            }
            return new DataResult<Customer>(ResultStatus.Error, "Böyle bir müşteri bulunamadı", null);
        }

        public async Task<IDataResult<IList<Customer>>> GetAll()
        {
            var customers= await _unitOfWork.Customers.GetAllAsync(null,c=>c.Orders);
            if (customers.Count>-1) 
            {
                return new DataResult<IList<Customer>>(ResultStatus.Success, customers);
            }
            return new DataResult<IList<Customer>>(ResultStatus.Error, "Böyle bir müşteri bulunamadı", null);
        }

        public Task<IDataResult<IList<Customer>>> GetAllByNonDeleted()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> HardDelete(int customerId)
        {

            var customer = await _unitOfWork.Customers.GetAsync(c => c.CustomerId == "customerId");
            if (customer != null)
            {
                await _unitOfWork.Customers.DeleteAsync(customer);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{customer.CompanyName} adlı müşteri başarıyla veritabanından silinmiştir");
            }
            return new Result(ResultStatus.Error, "Böyle bir müşteri bulunamadı", null);
        }


        public async Task<IResult> Update(CustomerUpdateDto customerUpdateDto)
        {
            var customer = await _unitOfWork.Customers.GetAsync(c => c.CustomerId == customerUpdateDto.CustomerId);
            if (customer != null)
            {
                customer.CompanyName = customerUpdateDto.CompanyName;
                customer.ContactName = customerUpdateDto.ContactName;
                customer.ContactTitle = customerUpdateDto.ContactTitle;
                customer.Address = customerUpdateDto.Address;
                customer.City = customerUpdateDto.City;
                customer.PostalCode = customerUpdateDto.PostalCode;
                customer.Country = customerUpdateDto.Country;
                customer.Phone = customerUpdateDto.Phone;
                customer.Region = customerUpdateDto.Region;
                customer.Fax = customerUpdateDto.Fax;
                await _unitOfWork.Customers.UpdateAsync(customer);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, $"{customerUpdateDto.CompanyName}adlı müşteri başarıyla güncellendi");
            }
            return new Result(ResultStatus.Error, "Böyle bir müşteri bulunamadı", null);
        }
    }
}
