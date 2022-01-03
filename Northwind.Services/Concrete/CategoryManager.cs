using AutoMapper;
using Northwind.Data.Abstract;
using Northwind.Entities.Concrete;
using Northwind.Entities.Dtos;
using Northwind.Services.Abstract;
using Northwind.Services.Utilities;
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
    public class CategoryManager:ICategoryServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.CategoryId == categoryId);
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, new CategoryDto
                {
                    Category = category,
                    ResultStatus = ResultStatus.Success
                    
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error,Messages.Category.NotFound(isPlural:false),new CategoryDto
           {
               Category = null,
               ResultStatus = ResultStatus.Error,
               Message = Messages.Category.NotFound(isPlural: false)
           });
        }

        public async Task<IDataResult<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, new CategoryListDto
                {
                    Categories = categories,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, "Hiç bir kategori bulunamadı.", null);
        }

       
     

        public async Task<IResult> Add(CategoryAddDto categoryAddDto)
        {
          
           
            var category = _mapper.Map<Category>(categoryAddDto);
           
            await _unitOfWork.Categories.AddAsync(category);
                await _unitOfWork.SaveAsync();
            //await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{categoryAddDto.CategoryName} adlı kategori başarıyla eklenmiştir.");
        }

        public async Task<IResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var category = _mapper.Map<Category>(categoryUpdateDto);
           
            await _unitOfWork.Categories.UpdateAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{categoryUpdateDto.CategoryName} adlı kategori başarıyla güncellenmiştir.");
        }

        public async Task<IResult> Delete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.CategoryId == categoryId);
            if (category != null)
            {
    
                await _unitOfWork.Categories.DeleteAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{category.CategoryName} adlı kategori başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadı.");
        }

    /*    public async Task<IResult> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.CategoryId == categoryId);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{category.CategoryName} adlı kategori başarıyla veritabanından silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle bir kategori bulunamadı.");
        }
    */
    }
}
