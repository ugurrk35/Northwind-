using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T>:IResult 
    {
        //out type örnek olarak ben bir kategoriyi tek başına olarak
        //taşıyabilriim yada Ilist yada IEnurameble oalrak taşıyabilriim


        public T Data { get; } //new DataResult<Category>(ResulStatus.Success,category);

                               //new DataResult<IList<Category>>(ResulStatus.Success,categoryList);
    
    
    }
}
