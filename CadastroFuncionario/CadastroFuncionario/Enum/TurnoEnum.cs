using System.Text.Json.Serialization;

namespace CadastroFuncionario.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum
    {
        Manha,
        Tarde,
        Noite
    }
}
