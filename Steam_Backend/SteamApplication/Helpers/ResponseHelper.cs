using SteamApplication.Models.Response;

namespace SteamApplication.Helpers
{
    public static class ResponseHelper
    {
        public static GenericResponse<T> Ok<T>(T data, string message = "OK")
        {
            return new GenericResponse<T>
            {
                Data = data,
                Message = message,
                Success = true
            };
        }

        public static GenericResponse<T> Fail<T>(string message)
        {
            return new GenericResponse<T>
            {
                Message = message,
                Success = false
            };
        }
    }
}
