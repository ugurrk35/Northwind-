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
    public interface IProductService
    {
        Task<IDataResult<ProductDto>> GetAsync(int productId);
        Task<IDataResult<ProductListDto>> GetAll();
        //Task<IDataResult<IList<ProductListDto>>> GetAllByNonDeleted();
        // Task<IDataResult<IList<ProductListDto>>> GetAllByNonDeletedAndActive();
        Task<IDataResult<ProductListDto>> GetAllByCategory(int categoryId);
        Task<IResult> Add(ProductAddDto productAddDto);
        Task<IResult> Update(ProductUpdateDto productUpdateDto);
        Task<IResult> HardDelete(int productId);
        Task<IResult> Delete(int productId);
    }
}
