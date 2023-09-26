using System.Net;

namespace ProjectArchitecture.Application.DTOs
{
    public class ResponseDTO<T>
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
    }
}
