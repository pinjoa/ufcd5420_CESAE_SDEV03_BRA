
using Agenda_Consts;
using SerializeTools;
using System.Xml.Serialization;

namespace Agenda_Configuration
{
    public class GlobalConfig
    {
        /// <summary>
        /// classe para serializar
        /// NOTA: caso seja necessário, pode/deve-se adicionar variáveis de configuração global
        /// </summary>
        [Serializable]
        public class GlobalConfigXml
        {
            [XmlElement]
            public string NpgsqlConnection { get; set; }

            public GlobalConfigXml()
            {
                NpgsqlConnection = "";
            }
            public GlobalConfigXml(string npgsqlConnection)
            {
                NpgsqlConnection = npgsqlConnection;
            }
        }
        /// <summary>
        /// variáveis privadas estáticas
        /// </summary>
        private static GlobalConfig? instancia;
        private static GlobalConfigXml _config;
        /// <summary>
        /// construtor privado, inicializa e impede a criação de objetos desta classe
        /// </summary>
        private GlobalConfig()
        {
            // inicializa a configuração com os valores por omissão
            _config = new GlobalConfigXml("Server=127.0.0.1;Port=5432;Database=AGENDA5DB;User Id=postgres;Password=postgres;");
            if (File.Exists(GlobalConfigFileName))
            {
                // carrega o ficheiro se existir
                LoadGlobalConfig();
            } 
            else
            {
                // cria o ficheiro se não existir
                SaveGlobalConfig();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GlobalConfigFileName => System.IO.Path.Combine(System.AppContext.BaseDirectory, Constantes.NomeXmlConfiguration);
        /// <summary>
        /// 
        /// </summary>
        public string NpgsqlConnection
        {
            get => _config.NpgsqlConnection;
            set
            {
                if (value.Trim().Length < 1) 
                {
                    throw new ArgumentException("NpgsqlConnection can't be empty!...");
                }
                _config.NpgsqlConnection = value;
                SaveGlobalConfig();
            }
        }
        /// <summary>
        /// carregar as configurações globais para a memória
        /// </summary>
        private void LoadGlobalConfig()
        {
            if (File.Exists(GlobalConfigFileName))
            {
                try
                {
                    _config = XmlMethods.DeserializeXmlToObject<GlobalConfigXml>(GlobalConfigFileName);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// gravar as configurações globais para um ficheiro XML
        /// </summary>
        private void SaveGlobalConfig()
        {
            try
            {
                XmlMethods.SerializeToXml<GlobalConfigXml>(_config, GlobalConfigFileName);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static GlobalConfig Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new GlobalConfig();
                }
                return instancia;
            }
        }

    }
}
