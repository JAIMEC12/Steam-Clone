namespace SteamShared.Constants
{
    public class ValidationConstants // Define la clase ValidationConstants que contiene constantes de mensajes de validación para ser
                                     // utilizadas en las anotaciones de validación de los modelos
    {
        public const string USER_NOT_FOUND = "Usuario no encontrado";
        public const string INVALID_DATA = "Datos inválidos";
        public const string INVALID_EMAIL = "El formato del correo electrónico es inválido";
        public const string MaxLength = "El maximo de caracteres es de {0}";
        public const string MinLength = "El minimo de caracteres es de {1}";
        public const string Required = "La propiedad {0} es requerida";
        public const string VALIDATION_MESSAGE = "Una o mas validaciones necesitan atencion";
    }
}