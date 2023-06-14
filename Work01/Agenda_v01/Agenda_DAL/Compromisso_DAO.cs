using Agenda_BO;

namespace Agenda_DAL
{
    public class Compromisso_DAO
    {
        private List<Compromisso> _compromissoList;
        /// <summary>
        /// 
        /// </summary>
        public Compromisso_DAO()
        {
            _compromissoList = new List<Compromisso>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="compromisso"></param>
        /// <returns></returns>
        public bool AdicionarCompromisso(Compromisso compromisso)
        {
            if (ReferenceEquals(compromisso, null)) return false;
            _compromissoList.Add(compromisso);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public bool ApagarCompromisso(string nome)
        {
            Compromisso? obj = null;
            string tNome = nome.Trim();
            if (ExisteCliente(tNome, out obj))
            {
                if (obj == null) return false;
                return _compromissoList.Remove(obj);
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public bool ExisteCliente(string nome)
        {
            Compromisso? obj = null;
            return ExisteCliente(nome, out obj);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ExisteCliente(string nome, out Compromisso? obj)
        {
            obj = null;
            string tNome = nome.Trim();
            if (tNome.Length == 0) return false;
            obj = _compromissoList.Find(c => c.Nome.CompareTo(tNome) == 0);
            return !ReferenceEquals(obj, null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> GetCompromissoList()
        {
            List<string> list = new List<string>();
            foreach (Compromisso c in _compromissoList)
            {
                list.Add(c.ToString());
            }
            return list;
        }
        
    }
}