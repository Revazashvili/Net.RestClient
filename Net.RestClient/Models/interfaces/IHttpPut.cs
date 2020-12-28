using System.Net.Http;
using System.Threading.Tasks;
using Net.RestClient.Models.Primitives;

namespace Net.RestClient.Models.interfaces
{
    public interface IHttpPut
    {
        Task<IResponse<TResponse>> PutAsync<T,TResponse>(T data,HttpClient _httpClient);
    }
}