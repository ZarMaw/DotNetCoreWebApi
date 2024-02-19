using DotNetCoreWebApi.Context;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebApi.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly CustomerDbContext _context;
        public BaseRepository(CustomerDbContext context)
        {
            this._context = context;
        }
        public virtual async Task Add(T entity)
        {
           await _context.AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
           _context.Remove(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var query = await _context.Set<T>().ToListAsync();
            return query;
        }

        public async Task<T> GetById(Guid id)
        {
           var query = await _context.Set<T>().FindAsync(id);
           return query;
        }

        public virtual async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
