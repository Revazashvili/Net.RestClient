using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Net.RestClient.Models.interfaces;
using Net.RestClient.Models.Primitives;

namespace Net.RestClient.Models.Entities
{
    public class RestClient : IRestClient
    {
        private readonly IHttpGet _httpGet;
        private readonly IHttpPost _httpPost;
        private readonly IHttpPut _httpPut;
        private readonly IHttpDelete _httpDelete;
        private readonly HttpClient _httpClient;
        public RestClient(IHttpGet httpGet,IHttpPost httpPost,IHttpPut httpPut,IHttpDelete httpDelete)
        {
            _httpGet = httpGet;
            _httpPost = httpPost;
            _httpPut = httpPut;
            _httpDelete = httpDelete;
            _httpClient = new HttpClient();
        }
        
        /// <summary>
        /// Makes Get Request 
        /// </summary>
        /// <typeparam name="T">Expected data to return</typeparam>
        /// <returns>IResponse<T></returns>
        public async Task<IResponse<T>> GetAsync<T>()
        {
            return await _httpGet.GetAsync<T>(_httpClient);
        }

        /// <summary>
        /// Makes Get Request with some content
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResponse">Expected data to return</typeparam>
        /// <returns>IResponse<TResponse></returns>
        public async Task<IResponse<TResponse>> GetAsync<T, TResponse>(T data)
        {
            return await _httpGet.GetAsync<T,TResponse>(data,_httpClient);
        }

        /// <summary>
        /// Makes Post Request
        /// </summary>
        /// <param name="data">Data to send request Uri</param>
        /// <typeparam name="T">Data Type Which is sent</typeparam>
        /// <typeparam name="TResponse">Type Expected to be returned</typeparam>
        /// <returns> IResponse<TResponse> </returns>
        public async Task<IResponse<TResponse>> PostAsync<T,TResponse>(T data)
        {
            return await _httpPost.PostAsync<T,TResponse>(data, _httpClient);
        }
        
        /// <summary>
        /// Makes Post Request
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>IResponse<T></returns>
        public async Task<IResponse<T>> PostAsync<T>(T data)
        {
            return await _httpPost.PostAsync<T>(data,_httpClient);
        }

        /// <summary>
        /// Makes Put Request
        /// </summary>
        /// <param name="data">Data to send request uri</param>
        /// <typeparam name="T">Data Type which is sent</typeparam>
        /// <typeparam name="TResponse">Type expected to return</typeparam>
        /// <returns>IResponse<TResponse></returns>
        public async Task<IResponse<TResponse>> PutAsync<T,TResponse>(T data)
        {
            return await _httpPut.PutAsync<T,TResponse>(data, _httpClient);
        }
        
        /// <summary>
        /// Makes Delete Request
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<IResponse<T>> DeleteAsync<T>(T data)
        {
            return await _httpDelete.DeleteAsync<T>(data, _httpClient);
        }
    }
}