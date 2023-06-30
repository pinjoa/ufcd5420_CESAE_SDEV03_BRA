namespace ToolBox
{
    /// <summary>
    /// implementa singleton
    /// </summary>
    public class GetNewId
    {
        private static GetNewId? instancia = null;
        private static int contador = 0;
        /// <summary>
        /// construtor privado para evitar instanciação desta classe
        /// </summary>
        private GetNewId() { }
        /// <summary>
        /// fornece o próximo Id
        /// </summary>
        public int Proximo => ++contador;
        /// <summary>
        /// fornece a instância
        /// </summary>
        public static GetNewId Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new GetNewId();
                }
                return instancia;
            }
        }
        /// <summary>
        /// necessário executar quando carregamos a base de dados XML, para evitar duplicação de Id's
        /// </summary>
        /// <param name="novoInicioContador"></param>
        public void ResetProximo(int novoInicioContador)
        {
            contador = novoInicioContador;
        }
    }
}