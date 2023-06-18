
using Agenda_Consts;
using System.Xml.Serialization;
using ToolBox;

namespace Agenda_BO
{
    /// <summary>
    /// estrutura para serialização
    /// </summary>
    [Serializable]
    public struct RegistoCompromisso
    {
        [XmlElement]
        public int Id { get; set; }
        [XmlElement]
        public DateTime Data { get; set; }
        [XmlElement]
        public int Bloco { get; set; }
        [XmlElement]
        public Prioridade Prioridade { get; set; }
        [XmlElement]
        public string Nome { get; set; }
        [XmlElement]
        public string Assunto { get; set; }
        [XmlElement]
        public TipoAgendamento TipoAgendamento { get; set; }
        [XmlElement]
        public bool Concluido { get; set; }
        [XmlElement]
        public DateTime Conclusao { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string? ToString()
        {
            return $"{Id}, {Data}\t{Nome}, {Assunto}";
        }
    }
    /// <summary>
    /// BO
    /// </summary>
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
        public Compromisso(DateTime data, int bloco, Prioridade prioridade, 
            string nome, string assunto, TipoAgendamento tipoAgendamento)
        {
            Id = GetNewId.Instancia.Proximo;
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
        /// <param name="registo"></param>
        public Compromisso(RegistoCompromisso registo) 
        {
            Id = registo.Id;
            Nome = registo.Nome;
            Assunto = registo.Assunto;
            Bloco = registo.Bloco;
            Prioridade = registo.Prioridade;
            Data = registo.Data;
            TipoAgendamento = registo.TipoAgendamento;
            Concluido = registo.Concluido;
            Conclusao = registo.Conclusao;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RegistoCompromisso RegistoCompromisso()
        {
            return new RegistoCompromisso {
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