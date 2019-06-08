using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDemo.DataLayer.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.DomainLayer.Repository
{
    public class Repository<Type> where Type : class
    {
        private DataContext _dbContext;
        private DbSet<Type> _set;
        public Repository(DataContext context)
        {
            _dbContext = context;
            _set = _dbContext.Set<Type>();
        }
        public async Task<List<Type>> GetAll()
        {
            return await _set.ToListAsync();
        }
        public  IQueryable<Type> GetAllQuerable()
        {
            return  _set;
        }

        public async Task<Type> GetByID(int id)
        {
            return await _set.FindAsync(id);
        }
        public async Task<bool> Add(Type entity)
        {
            await _set.AddAsync(entity);
            return await _dbContext.SaveChangesAsync() > 0;
            //return _dbContext.SaveChanges() > 0;
        }
        public async Task<bool> Update(Type entity)
        {
             _set.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
          //  return _dbContext.SaveChanges() > 0;
        }
        public async Task<bool> Delete(Type entity)
        {
            _set.Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
           // return _dbContext.SaveChanges() > 0;
        }
    
    }

}