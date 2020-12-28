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
    public class HttpPut : IHttpPut
    {
        private readonly RestClientConfiguration _configuration;
        private readonly Uri _uri;
        public HttpPut(RestClientConfiguration configuration)
        {
            _configuration = configuration;
            _uri = new Uri($"{_configuration.BaseAddress}/{_configuration.PutRequestUri}");
        }

        public async Task<IResponse<TResponse>> PutAsync<T, TResponse>(T data,HttpClient _httpClient)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                HttpContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await _httpClient.PutAsync(_uri,stringContent);
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