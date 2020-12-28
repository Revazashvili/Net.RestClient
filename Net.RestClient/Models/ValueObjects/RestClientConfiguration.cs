namespace Net.RestClient.Models.ValueObjects
{
    public class RestClientConfiguration
    {
        public string BaseAddress { get; set; }
        public string GetRequestUri { get; set; }
        public string GetByIdRequestUri { get; set; }
        public string PostRequestUri { get; set; }
        public string PutRequestUri { get; set; }
        public string DeleteRequestUri { get; set; }
    }
}