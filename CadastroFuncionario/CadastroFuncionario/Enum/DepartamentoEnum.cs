using System.Text.Json.Serialization;

namespace CadastroFuncionario.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
    {
        RH,
        Financeiro,
        Compras, 
        Atendimento,
        Zeladoria
    }
}
