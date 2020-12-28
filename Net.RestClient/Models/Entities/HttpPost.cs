using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Net.RestClient.Models.interfaces;
using Net.RestClient.Models.Primitives;
using Net.RestClient.Models.ValueObjects;
using Newtonsoft.Json;

namespace Net.RestClient.Models.Entities
{
    public class HttpPost : IHttpPost
    {
        private readonly RestClientConfiguration _configuration;
        private readonly Uri _uri;
        public HttpPost(RestClientConfiguration configuration)
        {
            _configuration = configuration;
            _uri = new Uri($"{_configuration.BaseAddress}/{_configuration.PostRequestUri}");
        }
        
        /// <summary>
        /// Makes Post Request
        /// </summary>
        /// <param name="data">Data to send request Uri</param>
        /// <typeparam name="T">Data Type Which is sent</typeparam>
        /// <typeparam name="TResponse">Type Expected to be returned</typeparam>
        /// <returns> IResponse<TResponse> </returns>
        public async Task<IResponse<TResponse>> PostAsync<T,TResponse>(T data,HttpClient _httpClient)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                HttpContent stringContent = new StringContent(json,Encoding.UTF8,"application/json");
                HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync(_uri,stringContent);
                var result = JsonConvert.DeserializeObject<TResponse>(await httpResponseMessage.Content.ReadAsStringAsync());
                var response = new Response<TResponse>(result);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<TResponse>(errorMessage:ex.Message);
            }
        }
        
        /// <summary>
        /// Makes Post Request
        /// </summary>
        /// <param name="data">Data to send request uri</param>
        /// <param name="_httpClient"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>IResponse<T></returns>
        public async Task<IResponse<T>> PostAsync<T>(T data, HttpClient _httpClient)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                HttpContent stringContent = new StringContent(json,Encoding.UTF8,"application/json");
                HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync(_uri,stringContent);
                var result = JsonConvert.DeserializeObject<T>(await httpResponseMessage.Content.ReadAsStringAsync());
                return new Response<T>(result);
            }
            catch (Exception ex)
            {
                return new Response<T>(errorMessage:ex.Message);
            }
        }
        
        /// <summary>
        /// Makes Post Request
        /// </summary>
        /// <param name="data"></param>
        /// <param name="_httpClient"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task Post<T>(T data, HttpClient _httpClient)
        {
            var json = JsonConvert.SerializeObject(data);
            HttpContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsync(_uri, stringContent);
            var result = JsonConvert.DeserializeObject<T>(await httpResponseMessage.Content.ReadAsStringAsync());
        }
    }
}