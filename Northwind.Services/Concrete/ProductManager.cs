using AutoMapper;
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

    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper=mapper;
        }
        public async Task<IResult> Add(ProductAddDto productAddDto)
        {
            var product =  _mapper.Map<Product>(productAddDto);
            await _unitOfWork.Products.AddAsync(product).ContinueWith(t=>_unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success,$"{productAddDto.ProductName} ürün başarıyla eklenmiştir");

        }

        public async Task<IResult> Delete(int productId)
        {
            var result=await _unitOfWork.Products.AnyAsync(p=>p.ProductId == productId);
            if (result)
            {
                var product=await _unitOfWork.Products.GetAsync(p=>p.ProductId == productId);
                await _unitOfWork.Products.UpdateAsync(product).ContinueWith(_ => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{product.ProductName} ürün başarıyla silinmiştir");

            }

            return new Result(ResultStatus.Error, $"Böyle bir ürün bulunamadı");
        }

        public async Task<IDataResult<ProductDto>> GetAsync(int productId)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.ProductId == productId, p => p.Supplier, p => p.Category);
            if(product!=null)
            {
                return new DataResult<ProductDto>(ResultStatus.Success, new ProductDto
                {
                    Product = product,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductDto>(ResultStatus.Error, "ürün bulunamadı",null);
        }

        public async Task<IDataResult<ProductListDto>> GetAll()
        {
           var products= await _unitOfWork.Products.GetAllAsync(null,p=>p.Supplier,p=>p.Category);
            if (products.Count>-1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Product=products,
                    ResultStatus=ResultStatus.Success
                });

            }
            return new DataResult<ProductListDto>(ResultStatus.Error, "ürünler bulunamadı", null);

        }

        public  Task<IDataResult<ProductListDto>> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Update(ProductUpdateDto productUpdateDto)
        {
            var product = _mapper.Map<Product>(productUpdateDto);
            await _unitOfWork.Products.UpdateAsync(product).ContinueWith(t=>_unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{productUpdateDto.ProductName} ürün başarıyla güncellenmiştir");

        }
    }
}
