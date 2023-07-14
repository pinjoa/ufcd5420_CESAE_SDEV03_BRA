

using Agenda_Consts;
using System.Text.Json.Serialization;

namespace Agenda_Models2Api
{
    public class AgendaRegistoResponse
    {
        [property: JsonPropertyName("id")]
        public int Id { get; set; }
        [property: JsonPropertyName("data")]
        public DateTime Data { get; set; }
        [property: JsonPropertyName("bloco")]
        public int Bloco { get; set; }
        [property: JsonPropertyName("prioridade")]
        public Prioridade Prioridade { get; set; }
        [property: JsonPropertyName("nome")]
        public string Nome { get; set; }
        [property: JsonPropertyName("assunto")]
        public string Assunto { get; set; }
        [property: JsonPropertyName("tipoagendamento")]
        public TipoAgendamento TipoAgendamento { get; set; }
        [property: JsonPropertyName("concluido")]
        public bool Concluido { get; set; }
        [property: JsonPropertyName("conclusao")]
        public DateTime Conclusao { get; set; }

    }
}
