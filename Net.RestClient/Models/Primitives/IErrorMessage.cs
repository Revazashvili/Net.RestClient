using System.Collections.Generic;

namespace Net.RestClient.Models.Primitives
{
    public interface IErrorMessage
    {
        string Key { get; set; }
        string Value { get; set; }
    }
}