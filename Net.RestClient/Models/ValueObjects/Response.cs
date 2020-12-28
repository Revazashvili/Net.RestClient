using System.Collections.Generic;
using System.Linq;
using Net.RestClient.Models.Primitives;
using Newtonsoft.Json;

namespace Net.RestClient.Models.ValueObjects
{
    public class Response<T> : IResponse<T>
    {
        #region Constructors
        
        public Response() { }

        public Response(T data) => Data = data;

        public Response(string errorMessage) =>
            ErrorMessage = new List<IErrorMessage>() {new ErrorMessage(value: errorMessage)};

        public Response(string key, string errorMessage) => ErrorMessage = new List<IErrorMessage>()
            {new ErrorMessage(key, errorMessage)};

        public Response(ErrorMessage errorMessage) => ErrorMessage = new List<IErrorMessage>() {errorMessage};

        public Response(IEnumerable<string> errorMessages) =>
            ErrorMessage = errorMessages.Select(x => new ErrorMessage(x, x)).ToList();

        public Response(IEnumerable<IErrorMessage> errorMessages) => ErrorMessage = errorMessages;
        
        #endregion

        private bool _succeeded;
        public T Data { get; }

        public bool Succeeded
        {
            get
            {
                return ErrorMessage == null || (ErrorMessage != null && ErrorMessage.Count() == 0);
            }
            set
            {
                _succeeded = value;
            }
        }

        private IEnumerable<IErrorMessage> _errorMessages;
        
        [JsonConverter(typeof(ConcreteTypeConverter<IEnumerable<IErrorMessage>>))]
        public IEnumerable<IErrorMessage> ErrorMessage
        {
            get
            {
                return _errorMessages;
            }
            set
            {
                _errorMessages = value;
            }
        }
    }
}