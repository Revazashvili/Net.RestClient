using System;
using System.Net.Http;
using System.Threading.Tasks;
using Net.RestClient.Models.interfaces;
using Net.RestClient.Models.Primitives;
using Net.RestClient.Models.ValueObjects;
using Newtonsoft.Json;

namespace Net.RestClient.Models.Entities
{
    public class HttpDelete : IHttpDelete
    {
        private readonly RestClientConfiguration _configuration;
        public HttpDelete(RestClientConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        /// <summary>
        /// Makes Delete Request
        /// </summary>
        /// <param name="data">Data to send to the request uri</param>
        /// <param name="_httpClient">HttpClient</param>
        /// <typeparam name="T">Type of data</typeparam>
        /// <returns>IResponse<T></returns>
        public async Task<IResponse<T>> DeleteAsync<T>(T data,HttpClient _httpClient)
        {
            try
            {
                var requestUri = new Uri($"{_configuration.BaseAddress}/{_configuration.DeleteRequestUri}?Id={data}");
                HttpResponseMessage httpResponseMessage =  await _httpClient.DeleteAsync(requestUri);
                var result = JsonConvert.DeserializeObject<T>(await httpResponseMessage.Content.ReadAsStringAsync());
                return new Response<T>(result);
            }
            catch (Exception ex)
            {
                return new Response<T>(errorMessage:ex.Message);
            }
        }
    }
}