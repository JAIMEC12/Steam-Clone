using SteamShared.Helpers;

namespace SteamApplication.Models.Response
{
    public class GenericResponse<T> // Define la clase genérica GenericResponse que se utiliza para encapsular la respuesta de una
                                    // solicitud, incluyendo un mensaje, un timestamp, los datos de la respuesta y un indicador de éxito
    {
        public string Message { get; set; }
        public DateTime TimeStamp { get; } = DateTimeHelper.UtcNow(); // Sirve para indicar la fecha y hora en que se generó la respuesta, se establece por defecto a la fecha y hora actual en formato UTC

        public T Data { get; set; }
        public bool Success { get; set; } = true;
    }
}