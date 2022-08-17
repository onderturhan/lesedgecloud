namespace EdgeCloud.LES.ClassLibrary.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
    }
}
