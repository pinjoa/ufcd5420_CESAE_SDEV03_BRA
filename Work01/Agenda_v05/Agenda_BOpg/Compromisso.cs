using Agenda_Consts;
using Agenda_Models2Api;

namespace Agenda_BOpg
{
    public class Compromisso
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Bloco { get; set; }
        public Prioridade Prioridade { get; set; }
        public string Nome { get; set; }
        public string Assunto { get; set; }
        public TipoAgendamento TipoAgendamento { get; set; }
        public bool Concluido { get; set; }
        public DateTime Conclusao { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="bloco"></param>
        /// <param name="prioridade"></param>
        /// <param name="nome"></param>
        /// <param name="assunto"></param>
        /// <param name="tipoAgendamento"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Compromisso(DateTime data, int bloco, Prioridade prioridade, 
            string nome, string assunto, TipoAgendamento tipoAgendamento)
        {
            Bloco = bloco;
            Data = data;
            Prioridade = prioridade;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome)); 
            Assunto = assunto ?? throw new ArgumentNullException(nameof(assunto));
            TipoAgendamento = tipoAgendamento;
            Concluido = false;
            Conclusao = new DateTime();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <param name="bloco"></param>
        /// <param name="prioridade"></param>
        /// <param name="nome"></param>
        /// <param name="assunto"></param>
        /// <param name="tipoAgendamento"></param>
        /// <param name="concluido"></param>
        /// <param name="conclusao"></param>
        public Compromisso(int id, DateTime data, int bloco, Prioridade prioridade, 
            string nome, string assunto, TipoAgendamento tipoAgendamento, bool concluido, 
            DateTime conclusao) : this(data, bloco, prioridade, nome, assunto, tipoAgendamento)
        {
            Id = id;
            Concluido = concluido;
            Conclusao = conclusao;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AgendaRegistoResponse RegistoCompromissoResponse()
        {
            return new AgendaRegistoResponse
            {
                Id = this.Id,
                Data = this.Data,
                Nome = this.Nome,
                Assunto = this.Assunto,
                Prioridade = this.Prioridade,
                TipoAgendamento = this.TipoAgendamento,
                Bloco = this.Bloco,
                Conclusao = this.Conclusao,
                Concluido = this.Concluido
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string? ToString()
        {
            //return base.ToString();
            return $"{Id}, {Data}\t{Nome}, {Assunto}";
        }
    }
}
