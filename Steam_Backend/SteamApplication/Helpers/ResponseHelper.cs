using SteamApplication.Models.Response;

namespace SteamApplication.Helpers
{
    public static class ResponseHelper
    {
        public static GenericResponse<T> Ok<T>(T data, string message = "Solicitud realizada con exito!") // SIRVE PARA CUANDO LA SOLICITUD SE
                                                                                                          // REALIZA CON EXITO, POR EJEMPLO,
                                                                                                          // SI EL USUARIO SE CREA CORRECTAMENTE O
                                                                                                          // SI SE ENCUENTRA UN USUARIO
        {
            return new GenericResponse<T>
            {
                Data = data,
                Message = message,
                Success = true
            };
        }

        public static GenericResponse<T> Fail<T>(string message) // sIRVE PARA CUANDO HAY UN ERROR EN LA SOLICITUD, POR EJEMPLO, SI EL
                                                                 // USUARIO NO EXISTE O SI HAY UN ERROR EN LA BASE DE DATOS
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
