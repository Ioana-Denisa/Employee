using BaseLibrary.Response;

namespace ClientLibrary.Services.Contracts
{
    public interface IGenericService<T>
    {
        Task<List<T>> GetAll(string baseUrl);
        Task<T> GetByID(int id, string baseUrl);
        Task<GeneralResponse> Insert(T item, string baseUrl);
        Task<GeneralResponse> Update(T item, string baseUrl);
        Task<GeneralResponse> DeleteByID(int id, string baseUrl);
    }
}
