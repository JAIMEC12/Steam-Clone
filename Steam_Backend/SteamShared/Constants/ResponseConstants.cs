namespace SteamShared.Constants
{
    public static class ResponseConstants
    {
        //Users
        public const string USER_NOT_EXISTS = "El usuario no existe";
        //Projects
        public const string PROJECT_NOT_EXISTS = "El proyecto no existe";

        public static string ErrorUnexpected(string traceId)
        {
            return $"Ha ocurrido un error inesperado: Contacto con soporte, mencionando el siguiente codigo de error: {traceId}";
        }
    }
}
