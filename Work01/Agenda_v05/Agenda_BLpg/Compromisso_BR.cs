using Agenda_BOpg;
using Agenda_DALpg;
using Agenda_Consts;
using Agenda_Models2Api;
using Npgsql;
using Agenda_Configuration;
using System.Data;

namespace Agenda_BLpg
{
    public class Compromisso_BR
    {
        private NpgsqlConnection _conn;
        private Compromisso_DAO _CompromissoDao;
        /// <summary>
        /// construtor
        /// </summary>
        public Compromisso_BR()
        {
            _conn = new NpgsqlConnection(GlobalConfig.Instancia.NpgsqlConnection);
            _CompromissoDao = new Compromisso_DAO(_conn);
        }
        /// <summary>
        /// destrutor é necessário para terminar a ligação com a base de dados
        /// </summary>
        ~Compromisso_BR()
        {
            if (_conn.State == ConnectionState.Open) _conn.Close();
            _conn.Dispose();
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
            string tAssunto = assunto.Trim();
            if (tAssunto.Length == 0) throw new ArgumentNullException(nameof(assunto));
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        public bool ModificarCompromisso(int id, Compromisso compromisso)
        {
            if (ReferenceEquals(compromisso, null)) return false;
            return _CompromissoDao.ModificarCompromisso(id, compromisso);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="compromisso"></param>
        /// <param name="novaHora"></param>
        /// <param name="novoBloco"></param>
        /// <returns></returns>
        public bool ModificarCompromisso(Compromisso compromisso, int novaHora, int novoBloco)
        {
            if (ReferenceEquals(compromisso, null)) return false;
            compromisso.Data = CalcularData(compromisso.Data, novaHora, novoBloco);
            return _CompromissoDao.ModificarCompromisso(compromisso.Id, compromisso);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AgendaRegistoResponse> GetCompromissoListResponse()
        {
            List<AgendaRegistoResponse> lista = new List<AgendaRegistoResponse>();
            foreach (var c in _CompromissoDao.GetCompromissos())
            {
                lista.Add(c.RegistoCompromissoResponse());
            }
            return lista;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ExisteCompromisso(int id, out Compromisso? obj)
        {
            obj = null;
            return _CompromissoDao.ExisteCompromisso(id, out obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomeCliente"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ExisteCompromisso(string nomeCliente, out Compromisso? obj)
        {
            obj = null;
            return _CompromissoDao.ExisteCompromisso(nomeCliente, out obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AgendaRegistoResponse? ObterCompromissoResponse(int id)
        {
            AgendaRegistoResponse? obj = null;
            Compromisso? compromisso = null;
            if (ExisteCompromisso(id, out compromisso))
            {
                obj = new AgendaRegistoResponse
                {
                    Id = compromisso.Id,
                    Data = compromisso.Data,
                    Bloco = compromisso.Bloco,
                    Prioridade = compromisso.Prioridade,
                    Nome = compromisso.Nome,
                    Assunto = compromisso.Assunto,
                    TipoAgendamento = compromisso.TipoAgendamento,
                    Concluido = compromisso.Concluido,
                    Conclusao = compromisso.Conclusao
                };
            }
            return obj;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool AdicionarCompromissoRequest(AgendaRegistoRequest request)
        {
            Compromisso compromisso = NovoCompromisso(
                request.Data,
                request.Data.Hour,
                request.Bloco,
                request.Prioridade,
                request.Nome,
                request.Assunto,
                request.TipoAgendamento);
            compromisso.Concluido = request.Concluido;
            compromisso.Conclusao = request.Conclusao;
            return AdicionarCompromisso(compromisso);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool ModificarCompromissoRequest(int id, AgendaRegistoRequest request)
        {
            Compromisso? obj = null;
            if (ExisteCompromisso(id, out obj))
            {
                obj.Data = request.Data;
                obj.Bloco = request.Bloco;
                obj.Prioridade = request.Prioridade;
                obj.Nome = request.Nome;
                obj.Assunto = request.Assunto;
                obj.TipoAgendamento = request.TipoAgendamento;
                obj.Concluido = request.Concluido;
                obj.Conclusao = request.Conclusao;
                return ModificarCompromisso(id, obj);
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ApagarCompromisso(int id)
        {
            return _CompromissoDao.ApagarCompromisso(id);
        }
    }
}