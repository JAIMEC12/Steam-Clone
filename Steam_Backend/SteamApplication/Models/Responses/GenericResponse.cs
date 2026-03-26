using SteamShared.Helpers;

namespace SteamApplication.Models.Response
{
    public class GenericResponse<T>
    {
        public string Message { get; set; }
        public DateTime TimeStamp { get; } = DateTimeHelper.UtcNow(); // Sirve para indicar la fecha y hora en que se generó la respuesta, se establece por defecto a la fecha y hora actual en formato UTC

        public T Data { get; set; }
        public bool Success { get; set; } = true;
    }
}