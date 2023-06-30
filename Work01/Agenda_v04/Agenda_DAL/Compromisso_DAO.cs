using Agenda_BO;
using Agenda_Consts;
using SerializeTools;
using System.Xml.Serialization;
using ToolBox;

namespace Agenda_DAL
{
    public class Compromisso_DAO
    {
        [XmlRoot(ElementName = "Compromissos")]
        public class CompromissosBD
        {
            public CompromissosBD()
            {
                Items = new List<RegistoCompromisso>();
            }

            [XmlElement(ElementName = "Compromisso")]
            public List<RegistoCompromisso> Items { get; set; }
        }


        private CompromissosBD _compromissoList;
        private DateTime _loaded;
        private DateTime _modified;
        /// <summary>
        /// 
        /// </summary>
        public Compromisso_DAO()
        {
            _compromissoList = new CompromissosBD();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        public bool AdicionarCompromisso(Compromisso compromisso)
        {
            if (ReferenceEquals(compromisso, null)) return false;
            return AdicionarCompromisso(compromisso.RegistoCompromisso());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        public bool AdicionarCompromisso(RegistoCompromisso compromisso)
        {
            _compromissoList.Items.Add(compromisso);
            _modified = DateTime.Now;
            return true;
        }

        public bool ModificarCompromisso(int id, Compromisso compromisso)
        {
            if (ReferenceEquals(compromisso, null)) return false;
            int tIndex = _compromissoList.Items.FindIndex(r => r.Id.Equals(id));
            if (tIndex > -1)
            {
                _compromissoList.Items[tIndex] = compromisso.RegistoCompromisso();
                _modified = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool ApagarCompromisso(string nomeCliente)
        {
            Compromisso? obj = null;
            string tNome = nomeCliente.Trim();
            if (ExisteCompromisso(tNome, out obj))
            {
                if (ReferenceEquals(obj, null)) return false;
                // apagar todos os registos com o nome igual ao "nome"
                if (_compromissoList.Items.RemoveAll(r => r.Nome.Equals(tNome)) > 0)
                {
                    _modified = DateTime.Now;
                    return true;
                }
            }
            return false;
        }

        public bool ApagarCompromisso(int id)
        {
            int tIndex = _compromissoList.Items.FindIndex(r => r.Id.Equals(id));
            if (tIndex > -1)
            {
                _compromissoList.Items.RemoveAt(tIndex);
                _modified = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool ExisteCompromisso(string nomeCliente)
        {
            Compromisso? obj = null;
            return ExisteCompromisso(nomeCliente, out obj);
        }

        public bool ExisteCompromisso(string nomeCliente, out Compromisso? obj)
        {
            obj = null;
            string tNome = nomeCliente.Trim();
            if (tNome.Length == 0) return false;
            int tIndex = _compromissoList.Items.FindIndex(r => r.Nome.Equals(tNome));
            if (tIndex > -1)
            {
                obj = new Compromisso(_compromissoList.Items[tIndex]);
                return true;
            }
            return false;
        }
        
        public bool ExisteCompromisso(int id, out Compromisso? obj)
        {
            obj = null;
            int tIndex = _compromissoList.Items.FindIndex(r => r.Id.Equals(id));
            if (tIndex > -1)
            {
                obj = new Compromisso(_compromissoList.Items[tIndex]);
                return true;
            }
            return false;
        }

        public List<string> GetCompromissoList()
        {
            List<string> list = new List<string>();
            foreach (RegistoCompromisso c in _compromissoList.Items)
            {
                list.Add(c.ToString());
            }
            return list;
        }

        public void ExportarDados()
        {
        	string ficheiro = System.IO.Path.Combine(System.AppContext.BaseDirectory, Constantes.NomeXmlCompromissos);
            if (_modified > _loaded || !File.Exists(ficheiro))
            {
                try
                {
                    ExportarXml(ficheiro);
                    _modified = _loaded = DateTime.Now;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool ExportarXml(string ficheiro)
        {
            if (ficheiro != null)
            {
                try
                {
                    XmlMethods.SerializeToXml<CompromissosBD>(_compromissoList, ficheiro);

                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }

        public bool ImportarDados()
        {
        	string ficheiro = System.IO.Path.Combine(System.AppContext.BaseDirectory, Constantes.NomeXmlCompromissos);
            return ImportarXml(ficheiro);
        }

        public bool ImportarXml(string ficheiro)
        {
            if (ficheiro != null && File.Exists(ficheiro))
            {
                try
                {
                    _compromissoList = XmlMethods.DeserializeXmlToObject<CompromissosBD>(ficheiro);
                    _loaded = DateTime.Now;
                    _modified = DateTime.Now;
                    // uma proposta de solução para evitar duplicação de Id's
                    // estratégia para se atualizar o gerador de Id's
                    if (_compromissoList.Items.Count > 0)
                    {
                        int tId = _compromissoList.Items[0].Id;
                        foreach (RegistoCompromisso r in _compromissoList.Items)
                        {
                            if (r.Id > tId) tId = r.Id;
                        }
                        GetNewId.Instancia.ResetProximo(tId);
                    }
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return false;
        }

        // serviços para o API
        public List<Compromisso> GetCompromissos()
        {
            List<Compromisso> list = new List<Compromisso>();
            foreach (RegistoCompromisso c in _compromissoList.Items)
            {
                list.Add(new Compromisso(c));
            }
            return list;
        }



    }
}