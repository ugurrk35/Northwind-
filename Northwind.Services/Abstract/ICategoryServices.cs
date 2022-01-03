using Northwind.Entities.Dtos;
using Northwind.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstract
{
    public interface ICategoryServices
    {
        Task<IDataResult<CategoryDto>> Get(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAll();
        Task<IResult> Add(CategoryAddDto categoryAddDto);
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto);
        Task<IResult> Delete(int categoryId);
       // Task<IResult> HardDelete(int categoryId);


    }
}
