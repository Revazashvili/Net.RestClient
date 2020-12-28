using System.Threading.Tasks;
using Net.RestClient.Models.Primitives;

namespace Net.RestClient.Models.interfaces
{
    public interface IRestClient
    {
        Task<IResponse<T>> GetAsync<T>();
        Task<IResponse<TResponse>> GetAsync<T,TResponse>(T data);
        Task<IResponse<TResponse>> PostAsync<T, TResponse>(T data);
        Task<IResponse<TResponse>> PutAsync<T,TResponse>(T data);
        Task<IResponse<T>> DeleteAsync<T>(T data);
    }
}