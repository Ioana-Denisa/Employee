using BaseLibrary.Response;

namespace ServerLibrary.Repositories.Contracts
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetByID(int id);
        Task<GeneralResponse> Insert(T item);
        Task<GeneralResponse> Update(T item);
        Task<GeneralResponse> DeleteByID(int id);
    }
}
