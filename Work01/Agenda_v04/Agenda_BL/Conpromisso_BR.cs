using Agenda_BO;
using Agenda_DAL;
using Agenda_Consts;
using Agenda_Models2Api;

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
        /// <param name="bloco"></param>
        /// <returns></returns>
        private int ValidarBloco(int bloco)
        {
            return bloco < 1 ? 1 : (bloco > 4 ? 4 : bloco);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hora"></param>
        /// <returns></returns>
        private int ValidarHora(int hora)
        {
            return hora < 0 ? 0 : (hora > 23 ? 23 : hora);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hora"></param>
        /// <param name="bloco"></param>
        /// <returns></returns>
        private DateTime CalcularData(DateTime data, int hora, int bloco)
        {
            return new DateTime(data.Year, data.Month, data.Day,
                ValidarHora(hora), (ValidarBloco(bloco) - 1) * 15, 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hora"></param>
        /// <param name="bloco"></param>
        /// <param name="prioridade"></param>
        /// <param name="nomeCliente"></param>
        /// <param name="assunto"></param>
        /// <param name="tipoAgendamento"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Compromisso NovoCompromisso(DateTime data, int hora, int bloco, 
            Prioridade prioridade, string nomeCliente, string assunto, 
            TipoAgendamento tipoAgendamento)
        {
            int tBloco = ValidarBloco(bloco);
            DateTime tData = CalcularData(data, hora, tBloco);
            Prioridade tPrioridade = prioridade;
            string tNome = nomeCliente.Trim();
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
        /// <param name="nomeCliente"></param>
        /// <param name="assunto"></param>
        /// <param name="prioridade"></param>
        /// <param name="tipoAgendamento"></param>
        /// <returns></returns>
        public Compromisso NovoCompromisso(int hora, int bloco, string nomeCliente, string assunto,
            Prioridade prioridade = Prioridade.Media,
            TipoAgendamento tipoAgendamento = TipoAgendamento.Profissional)
        {
            return NovoCompromisso(DateTime.Now, hora, bloco, 
                prioridade, nomeCliente, assunto, tipoAgendamento);
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
        /// <param name="nomeCliente"></param>
        /// <returns></returns>
        public bool ApagarCompromisso(string nomeCliente)
        {
            return _CompromissoDao.ApagarCompromisso(nomeCliente);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomeCliente"></param>
        /// <returns></returns>
        public bool ExisteCompromisso(string nomeCliente)
        {
            return _CompromissoDao.ExisteCompromisso(nomeCliente);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GetCompromissoList()
        {
            return _CompromissoDao.GetCompromissoList();
        }

        public bool ModificarCompromisso(int id, Compromisso compromisso)
        {
            if (ReferenceEquals(compromisso, null)) return false;
            return _CompromissoDao.ModificarCompromisso(id, compromisso);
        }

        public bool ModificarCompromisso(Compromisso compromisso, int novaHora, int novoBloco)
        {
            if (ReferenceEquals(compromisso, null)) return false;
            compromisso.Data = CalcularData(compromisso.Data, novaHora, novoBloco);
            return _CompromissoDao.ModificarCompromisso(compromisso.Id, compromisso);
        }

        public void ExportarDados()
        {
            _CompromissoDao.ExportarDados();
        }

        public bool ImportarDados()
        {
            return _CompromissoDao.ImportarDados();
        }

        // serviços para o API
        public List<AgendaRegistoResponse> GetCompromissoListResponse()
        {
            List<AgendaRegistoResponse> lista = new List<AgendaRegistoResponse>();
            foreach (var c in _CompromissoDao.GetCompromissos())
            {
                //lista.Add(c.RegistoCompromissoResponse());
            }
            return lista;
        }

    }
}