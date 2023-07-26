

namespace steven_api.Wrappers
{
    public class ApiResponse<T>
    {
            public T Data { get; set; }
            public bool Succeeded { get; set; }
            public string[] Errors { get; set; }
            public string Message { get; set; }
        public ApiResponse()
        {
        }
        public static ApiResponse<T> Fail(string errorMessage)
        {
            return new ApiResponse<T> { 
                Succeeded = false,
                Message = errorMessage,
                Errors = null
            };
        }
        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T> { 
                Succeeded = true,
                Message = "Success",
                Errors = null,
                Data = data
            };
        }
    }
}