using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Database.Models;

namespace WebServer.Database.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity, int id);

        Task DeleteAsync(int id);
    }
}
