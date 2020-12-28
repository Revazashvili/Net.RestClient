using System;
using System.Net.Http;
using System.Threading.Tasks;
using Net.RestClient.Models.Primitives;

namespace Net.RestClient.Models.interfaces
{
    public interface IHttpPost
    {
        Task<IResponse<TResponse>> PostAsync<T,TResponse>(T data,HttpClient _httpClient);
        Task<IResponse<T>> PostAsync<T>(T data,HttpClient _httpClient);
        Task Post<T>(T data, HttpClient _httpClient);
    }
}