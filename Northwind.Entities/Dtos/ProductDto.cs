using Northwind.Entities.Concrete;
using Northwind.Shared.Entities.Abstract;
using Northwind.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Dtos
{
    public class ProductDto : DtoGetBase
    {
        public Product Product { get; set; }
        //public ResultStatus ResultStatus { get; set; }=ResultStatus.Success;
    }
}
