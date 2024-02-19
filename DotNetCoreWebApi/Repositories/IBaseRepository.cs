
namespace DotNetCoreWebApi.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
    }
}
