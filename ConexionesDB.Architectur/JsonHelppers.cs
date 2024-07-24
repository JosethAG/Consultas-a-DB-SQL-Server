using System.Text.Json;

namespace ConexionesDB.Architectur
{
    public class JsonHelppers
    {
        /*Metodo para desearealizar información de Json a T Clase
         Incorporado el 24/7/24 por Joseth Araya
         */
        public static T? DeserializeSimple<T>(string content) where T : class
        {
            return JsonSerializer.Deserialize<T>(content, GetJsonSerializerOptions());
        }

        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
            };
        }
    }
}
