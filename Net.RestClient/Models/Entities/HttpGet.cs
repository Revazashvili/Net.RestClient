using System;
using System.Net.Http;
using System.Threading.Tasks;
using Net.RestClient.Models.interfaces;
using Net.RestClient.Models.Primitives;
using Net.RestClient.Models.ValueObjects;
using Newtonsoft.Json;

namespace Net.RestClient.Models.Entities
{
    public class HttpGet : IHttpGet
    {
        private readonly RestClientConfiguration _configuration;
        public HttpGet(RestClientConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        /// <summary>
        /// Get Request Method 
        /// </summary>
        /// <typeparam name="T">Expected data to return</typeparam>
        /// <returns>IResponse<T></returns>
        public async Task<IResponse<T>> GetAsync<T>(HttpClient _httpClient)
        {
            try
            {
                var requestUri = new Uri($"{_configuration.BaseAddress}/{_configuration.GetRequestUri}");
                HttpResponseMessage httpResponseMessage =  await _httpClient.GetAsync(requestUri);
                var result = JsonConvert.DeserializeObject<T>(await httpResponseMessage.Content.ReadAsStringAsync());
                return new Response<T>(result);
            }
            catch (Exception ex)
            {
                return new Response<T>(errorMessage:ex.Message);
            }
        }
        
        /// <summary>
        /// Get Request Method with some context
        /// </summary>
        /// <param name="data">data to send to request uri</param>
        /// <param name="_httpClient"></param>
        /// <typeparam name="T">Data Type to send to request uri</typeparam>
        /// <typeparam name="TResponse">Expected data to return</typeparam>
        /// <returns>IResponse<TResponse></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IResponse<TResponse>> GetAsync<T, TResponse>(T data, HttpClient _httpClient)
        {
            try
            {
                var requestUri = new Uri($"{_configuration.BaseAddress}/{_configuration.GetByIdRequestUri}?Id={data}");
                HttpResponseMessage httpResponseMessage =  await _httpClient.GetAsync(requestUri);
                var result = JsonConvert.DeserializeObject<TResponse>(await httpResponseMessage.Content.ReadAsStringAsync());
                return new Response<TResponse>(result);
            }
            catch (Exception ex)
            {
                return new Response<TResponse>(errorMessage:ex.Message);
            }
        }
    }
}