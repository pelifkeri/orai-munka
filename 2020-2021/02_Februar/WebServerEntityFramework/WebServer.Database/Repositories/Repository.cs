using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Database.Exceptions;
using WebServer.Database.Interfaces;
using WebServer.Database.Models;

namespace WebServer.Database.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext _dbContext;

        public Repository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            var result = await _dbContext.Set<T>().ToListAsync();

            if (result.Count == 0)
            {
                throw new EntityNotFoundException();
            }

            return result;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T newEntity, int id)
        {
            T entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            _dbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
