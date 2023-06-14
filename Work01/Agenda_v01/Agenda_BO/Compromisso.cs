
using Agenda_Consts;

namespace Agenda_BO
{
    public class Compromisso
    {
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
        public Compromisso(DateTime data, int bloco, Prioridade prioridade, 
            string nome, string assunto, TipoAgendamento tipoAgendamento)
        {
            Bloco = bloco;
            Data = data;
            Prioridade = prioridade;
            Nome = nome;
            Assunto = assunto;
            TipoAgendamento = tipoAgendamento;
            Concluido = false;
            Conclusao = new DateTime();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string? ToString()
        {
            //return base.ToString();
            return $"{Data}\t{Nome}, {Assunto}";
        }
    }
}