using System.Net;

namespace CharityApp.ResponseModels
{
    public class RequestResponse<T>
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Result { get; set; }
    }
    public class RequestResponse : RequestResponse<object>
    { }
}
