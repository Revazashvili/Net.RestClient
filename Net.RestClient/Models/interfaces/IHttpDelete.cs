using System.Net.Http;
using System.Threading.Tasks;
using Net.RestClient.Models.Primitives;

namespace Net.RestClient.Models.interfaces
{
    public interface IHttpDelete
    {
        Task<IResponse<T>> DeleteAsync<T>(T data,HttpClient _httpClient);
    }
}