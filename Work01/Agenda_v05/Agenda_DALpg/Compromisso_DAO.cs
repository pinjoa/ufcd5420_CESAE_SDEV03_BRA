
using Agenda_BOpg;
using Agenda_Consts;
using Npgsql;
using System.Data;

namespace Agenda_DALpg
{
    public class Compromisso_DAO
    {
        private NpgsqlConnection _conn;
        /// <summary>
        /// 
        /// </summary>
        public Compromisso_DAO(NpgsqlConnection _conn)
        {
            this._conn = _conn;
        }
        /// <summary>
        /// 
        /// </summary>
        public NpgsqlConnection Db => _conn;
        /// <summary>
        /// 
        /// </summary>
        public void DbOpen()
        {
            if (Db.State != ConnectionState.Open) Db.Open();
        }
        /// <summary>
        /// 
        /// </summary>
        public void DbClose()
        {
            if (Db.State == ConnectionState.Open) Db.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        public bool AdicionarCompromisso(Compromisso compromisso)
        {
            if (ReferenceEquals(compromisso, null)) return false;
            // ATENÇÃO: não deve incluir o ID na expressão SQL porque será gerado automaticamente...
            string sqltxt = "INSERT INTO public.compromissos"+
                "(data, bloco, prioridade, nome, assunto, tipoagendamento, concluido, conclusao) "+
                "VALUES (@data, @bloco, @prioridade, @nome, @assunto, @tipoagendamento, @concluido, @conclusao);";
            NpgsqlTransaction? tr = null;
            try
            {
                DbOpen();
                tr = Db.BeginTransaction();
                NpgsqlCommand com1 = new NpgsqlCommand(sqltxt, Db);
                com1.Parameters.AddWithValue("@data", compromisso.Data);
                com1.Parameters.AddWithValue("@bloco", compromisso.Bloco);
                com1.Parameters.AddWithValue("@prioridade", (int)compromisso.Prioridade);
                com1.Parameters.AddWithValue("@nome", compromisso.Nome);
                com1.Parameters.AddWithValue("@assunto", compromisso.Assunto);
                com1.Parameters.AddWithValue("@tipoagendamento", (int)compromisso.TipoAgendamento);
                com1.Parameters.AddWithValue("@concluido", compromisso.Concluido);
                com1.Parameters.AddWithValue("@conclusao", compromisso.Conclusao);
                int resultado = com1.ExecuteNonQuery();
                tr.Commit();
                tr.Dispose();
                tr = null;
                com1.Dispose();
                return resultado != -1;
            }
            catch (Exception e)
            {
                if (tr != null)
                {
                    tr.Rollback();
                    tr.Dispose();
                }
                throw new Exception("Erro ao adicionar compromisso!", e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool ModificarCompromisso(int id, Compromisso compromisso)
        {
            if (ReferenceEquals(compromisso, null)) return false;
            string sqltxt = "UPDATE public.compromissos " +
            "SET data=@data, bloco=@bloco, prioridade=@prioridade, nome=@nome, assunto=@assunto, "+
            "tipoagendamento=@tipoagendamento, concluido=@concluido, conclusao=@conclusao "+
            "WHERE id=@id;";
            NpgsqlTransaction? tr = null;
            try
            {
                DbOpen();
                tr = Db.BeginTransaction();
                NpgsqlCommand com1 = new NpgsqlCommand(sqltxt, Db);
                com1.Parameters.AddWithValue("@id", compromisso.Id);
                com1.Parameters.AddWithValue("@data", compromisso.Data);
                com1.Parameters.AddWithValue("@bloco", compromisso.Bloco);
                com1.Parameters.AddWithValue("@prioridade", (int)compromisso.Prioridade);
                com1.Parameters.AddWithValue("@nome", compromisso.Nome);
                com1.Parameters.AddWithValue("@assunto", compromisso.Assunto);
                com1.Parameters.AddWithValue("@tipoagendamento", (int)compromisso.TipoAgendamento);
                com1.Parameters.AddWithValue("@concluido", compromisso.Concluido);
                com1.Parameters.AddWithValue("@conclusao", compromisso.Conclusao);
                int resultado = com1.ExecuteNonQuery();
                tr.Commit();
                tr.Dispose();
                tr = null;
                com1.Dispose();
                return resultado == 1;
            }
            catch (Exception e)
            {
                if (tr != null)
                {
                    tr.Rollback();
                    tr.Dispose();
                }
                throw new Exception("Erro ao modificar compromisso!", e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomeCliente"></param>
        /// <returns></returns>
        public bool ApagarCompromisso(string nomeCliente)
        {
            Compromisso? obj = null;
            string tNome = nomeCliente.Trim();
            int contador = 0;
            while (ExisteCompromisso(tNome, out obj))
            {
                if (ApagarCompromisso(obj.Id))
                {
                    contador++;
                }
                else
                {
                    // não conseguiu apagar, deve-se interromper para evitar loop infinito...
                    break;
                }
            }
            return contador > 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool ApagarCompromisso(int id)
        {
            string sqltxt = "DELETE FROM public.compromissos WHERE id=@id;";
            NpgsqlTransaction? tr = null;
            try
            {
                DbOpen();
                tr = Db.BeginTransaction();
                NpgsqlCommand com1 = new NpgsqlCommand(sqltxt, Db);
                com1.Parameters.AddWithValue("@id", id);
                int resultado = com1.ExecuteNonQuery();
                tr.Commit();
                tr.Dispose();
                tr = null;
                com1.Dispose();
                return resultado != -1;
            }
            catch (Exception e)
            {
                if (tr != null)
                {
                    tr.Rollback();
                    tr.Dispose();
                }
                throw new Exception("Erro ao apagar compromisso!", e);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomeCliente"></param>
        /// <returns></returns>
        public bool ExisteCompromisso(string nomeCliente)
        {
            Compromisso? obj = null;
            return ExisteCompromisso(nomeCliente, out obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomeCliente"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool ExisteCompromisso(string nomeCliente, out Compromisso? obj)
        {
            obj = null;
            string tNome = nomeCliente.Trim();
            if (tNome.Length == 0) return false;
            string sqltxt = "SELECT id FROM public.compromissos WHERE nome=@nome;";
            try
            {
                DbOpen();
                NpgsqlCommand qry1 = new NpgsqlCommand(sqltxt, Db);
                qry1.Parameters.AddWithValue("@nome", tNome);
                NpgsqlDataReader res1 = qry1.ExecuteReader();
                if (res1.HasRows && res1.Read())
                {
                    int id = res1.GetInt32(res1.GetOrdinal("id"));
                    res1.Close();
                    return ExisteCompromisso(id, out obj);
                }
                if (!res1.IsClosed) res1.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter compromisso por nome!", e);
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool ExisteCompromisso(int id, out Compromisso? obj)
        {
            bool resultado = false;
            obj = null;
            string sqltxt = "SELECT id, data, bloco, prioridade, nome, assunto, "+
                "tipoagendamento, concluido, conclusao FROM public.compromissos WHERE id=@id;";
            try
            {
                DbOpen();
                NpgsqlCommand qry1 = new NpgsqlCommand(sqltxt, Db);
                qry1.Parameters.AddWithValue("@id", id);
                NpgsqlDataReader res1 = qry1.ExecuteReader();
                if (res1.HasRows && res1.Read())
                {
                    DateTime tmpData = res1.GetDateTime(res1.GetOrdinal("data"));
                    byte tmpBloco = res1.GetByte(res1.GetOrdinal("bloco"));
                    Prioridade tmpPrioridade = (Prioridade)res1.GetByte(res1.GetOrdinal("prioridade"));
                    string tmpNome = res1["nome"].ToString();
                    string tmpAssunto = res1["assunto"].ToString();
                    TipoAgendamento tmpTipoAgendamento = (TipoAgendamento)res1.GetByte(res1.GetOrdinal("tipoagendamento")); ;
                    bool tmpConcluido = res1.GetBoolean(res1.GetOrdinal("concluido"));
                    DateTime tmpConclusao = res1.GetDateTime(res1.GetOrdinal("conclusao"));
                    res1.Close();
                    obj = new Compromisso(id, tmpData, tmpBloco, tmpPrioridade, 
                        tmpNome, tmpAssunto, tmpTipoAgendamento, tmpConcluido, tmpConclusao);
                    resultado = true;
                }
                if (!res1.IsClosed) res1.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter compromisso por id!", e);
            }
            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<string> GetCompromissoList()
        {
            List<string> list = new List<string>();
            string sqltxt = "SELECT id, data, nome, assunto FROM public.compromissos;";
            try
            {
                DbOpen();
                NpgsqlCommand qry1 = new NpgsqlCommand(sqltxt, Db);
                NpgsqlDataReader res1 = qry1.ExecuteReader();
                if (res1.HasRows)
                {
                    while (res1.Read())
                    {
                        int tmpId = res1.GetInt32(res1.GetOrdinal("id"));
                        DateTime tmpData = res1.GetDateTime(res1.GetOrdinal("data"));
                        string tmpNome = res1["nome"].ToString();
                        string tmpAssunto = res1["assunto"].ToString();

                        list.Add($"{tmpId}, {tmpData}\t{tmpNome}, {tmpAssunto}");
                    }
                }
                if (!res1.IsClosed) res1.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter lista<string> de compromissos!", e);
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Compromisso> GetCompromissos()
        {
            List<Compromisso> list = new List<Compromisso>();
            string sqltxt = "SELECT id, data, nome, assunto FROM public.compromissos;";
            try
            {
                // passo 1
                // é necessário obter uma lista de id da tabela
                List<int> listaIds = new List<int>();
                DbOpen();
                NpgsqlCommand qry1 = new NpgsqlCommand(sqltxt, Db);
                NpgsqlDataReader res1 = qry1.ExecuteReader();
                if (res1.HasRows)
                {
                    while (res1.Read())
                    {
                        int tmpId = res1.GetInt32(res1.GetOrdinal("id"));
                        listaIds.Add(tmpId);
                    }
                }
                if (!res1.IsClosed) res1.Close();

                // passo 2
                // obter objetos e criar a lista
                Compromisso? obj;
                foreach (int id in listaIds)
                {
                    if (ExisteCompromisso(id, out obj))
                    {
                        list.Add(obj);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao obter lista<string> de compromissos!", e);
            }
            return list;
        }

    }
}
