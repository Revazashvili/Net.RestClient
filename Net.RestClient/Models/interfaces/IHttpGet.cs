using System.Net.Http;
using System.Threading.Tasks;
using Net.RestClient.Models.Primitives;

namespace Net.RestClient.Models.interfaces
{
    public interface IHttpGet
    {
        Task<IResponse<T>> GetAsync<T>(HttpClient _httpClient);
        Task<IResponse<TResponse>> GetAsync<T,TResponse>(T data,HttpClient _httpClient);
    }
}