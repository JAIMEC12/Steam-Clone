namespace SteamShared.Cache
{
    public class Cache<T>
    {
        private readonly Dictionary<string, T> _data = new();

        public T Add(string key, T data)
        {
            _data[key] = data; //Evita que se dupliquen las claves, si ya existe la clave se sobreescribe el valor
            return data;
        }

        public T? Get(string key)
        {
            return _data.TryGetValue(key, out var value) ? value : default; // El método TryGetValue devuelve true si se
                                                                            // encontró la clave y asigna el valor a la variable 'value',
                                                                            // o false si no se encontró la clave. Si se encuentra la
                                                                            // clave, se devuelve el valor; de lo contrario,
                                                                            // se devuelve el valor predeterminado para el tipo T
                                                                            // (que puede ser null si T es un tipo de referencia).
        }

        public List<T> GetAll()
        {
            return _data.Values.ToList(); // Devuelve una lista con todos los valores almacenados en el diccionario
        }

        public bool Delete(string key)
        {
            return _data.Remove(key); // El método Remove devuelve true si se eliminó el elemento correctamente, o false si no se encontró
                                      // la clave
        }



    }
}
