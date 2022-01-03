using Microsoft.EntityFrameworkCore;
using Northwind.Shared.Data.Abstract;
using Northwind.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Shared.Data.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        
        private readonly DbContext _context;
        public EfEntityRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity); //TEntity ye set ile abone oluyoruz burda customer order employee de olabilir
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            //bool olduğundan dolayı return dönücez
            return await _context.Set<TEntity>().AnyAsync(predicate);

        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity> ().CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            //Burada remove bir async değil o yüzden task i kendimiz oluşturmamız lazım
            //task işlemi kendimiz olşuşturduk
            //await _context.Set<TEntity>().Remove(entity);
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {//predicate null olma durumu olduğu için kontrol etmemiz gerekli
            //includeProperties de bu işlemleri kullanacağımız için 
            //predicate gelen değerleri query ye ekliyebiliriz
            IQueryable<TEntity> query= _context.Set<TEntity>();
            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            if(includeProperties.Any()) //dizin içerinde herhangi bir değer var mı
            {
                foreach(var includeProperty in includeProperties) 
                {
                    query= query.Include(includeProperty);//bana 5 tane gelir 5 kere gelir query include etmiş luruz
                }
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any()) //dizin içerinde herhangi bir değer var mı
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);//bana 5 tane gelir 5 kere gelir query include etmiş luruz
                }
            }
            return await query.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
          await Task.Run(() => { _context.Set<TEntity>().Update(entity); }); 
        }
    }
}
