using System.Collections.Generic;

namespace Net.RestClient.Models.Primitives
{
    public interface IResponse<T>
    {
        T Data { get; }
        bool Succeeded { get; }
        IEnumerable<IErrorMessage> ErrorMessage { get; }
    }
}