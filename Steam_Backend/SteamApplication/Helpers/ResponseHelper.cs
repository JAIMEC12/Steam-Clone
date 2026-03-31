using SteamApplication.Models.Response;

namespace SteamApplication.Helpers
{
    public static class ResponseHelper
    {
        public static GenericResponse<T> Ok<T>(T data, string message = "Solicitud realizada")
        {
            return new GenericResponse<T>
            {
                Data = data,
                Message = message,
                Success = true
            };
        }

        public static GenericResponse<T> Fail<T>(string message = "Solicitud rechazada")
        {
            return new GenericResponse<T>
            {
                Message = message,
                Success = false
            };
        }

        public static GenericResponse<T> Create<T>(T data, string message = "Solicitud realizada")
        {
            var response = new GenericResponse<T>
            {
                Data = data,
                Message = message,
            };
            return response;
        }
    }
}
