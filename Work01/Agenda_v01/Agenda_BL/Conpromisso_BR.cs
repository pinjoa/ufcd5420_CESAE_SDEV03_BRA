using Agenda_BO;
using Agenda_DAL;
using Agenda_Consts;

namespace Agenda_BL
{
    public class Compromisso_BR
    {
        private Compromisso_DAO _CompromissoDao;
        /// <summary>
        /// 
        /// </summary>
        public Compromisso_BR()
        {
            _CompromissoDao = new Compromisso_DAO();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hora"></param>
        /// <param name="bloco"></param>
        /// <param name="prioridade"></param>
        /// <param name="nome"></param>
        /// <param name="assunto"></param>
        /// <param name="tipoAgendamento"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Compromisso NovoCompromisso(DateTime data, int hora, int bloco, 
            Prioridade prioridade, string nome, string assunto, 
            TipoAgendamento tipoAgendamento)
        {
            int tBloco = bloco < 1 ? 1 : (bloco > 4 ? 4 : bloco);
            DateTime tData = new DateTime(data.Year, data.Month, data.Day, 
                hora, (tBloco - 1) * 15, 0);
            Prioridade tPrioridade = prioridade;
            string tNome = nome.Trim();
            if (tNome.Length == 0) throw new ArgumentNullException(nameof(tNome));
            string tAssunto = assunto ?? throw new ArgumentNullException(nameof(assunto));
            TipoAgendamento tTipoAgendamento = tipoAgendamento;
            return new Compromisso(tData, tBloco, tPrioridade, tNome, 
                tAssunto, tTipoAgendamento);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hora"></param>
        /// <param name="bloco"></param>
        /// <param name="nome"></param>
        /// <param name="assunto"></param>
        /// <param name="prioridade"></param>
        /// <param name="tipoAgendamento"></param>
        /// <returns></returns>
        public Compromisso NovoCompromisso(int hora, int bloco, string nome, string assunto,
            Prioridade prioridade = Prioridade.Media,
            TipoAgendamento tipoAgendamento = TipoAgendamento.Profissional)
        {
            return NovoCompromisso(DateTime.Now, hora, bloco, 
                prioridade, nome, assunto, tipoAgendamento);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        public bool AdicionarCompromisso(Compromisso compromisso)
        {
            if (ReferenceEquals(compromisso, null)) return false;
            return _CompromissoDao.AdicionarCompromisso(compromisso);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public bool ApagarCompromisso(string nome)
        {
            return _CompromissoDao.ApagarCompromisso(nome);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public bool ExisteCliente(string nome)
        {
            return _CompromissoDao.ExisteCliente(nome);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GetCompromissoList()
        {
            return _CompromissoDao.GetCompromissoList();
        }

    }
}