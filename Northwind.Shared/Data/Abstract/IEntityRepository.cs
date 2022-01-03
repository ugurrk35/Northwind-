using Northwind.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        Task<T> GetAsync(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties);
        //var kullanıcı=repository.GetAsync(k=>k.Id==15)
        //params Expression<Func<T,object>>[] includeProperties  customerin yanında order da getirebiliriz
        //object array oalcak mesala customerin orderlarına listelemek isteyebilirim birden fazla includeProperties verebilceğimiz için params ekliyoruz.
        //var customer =repository.GetAsync(x=>x.Id==25,x=>x.Order,x=>x.Shipper);


        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
   
    
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        //uğur isminde bir müşteri varmı
        //var result=_employeeRepository.AnyAsync(c=>c.FirstName=="Uğur")
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

    }
}
