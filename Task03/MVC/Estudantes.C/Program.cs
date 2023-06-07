
using Estudantes.C.Controller;
using Estudantes.C.Model;
using Estudantes.C.ToolBox;
using Estudantes.C.View;

namespace Estudantes.C
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ILer iLer = new LerDadosConsola();
            IEscrever iEscrever = new EscreverDadosConsola();
            EstudanteService eService = new EstudanteService();
            EstudanteView view = new EstudanteView(iLer, iEscrever, eService);
            EstudanteController controller = new EstudanteController(view, eService);
            
            // exibir lista de estudantes
            controller.ExibirListaEstudantes();
            
            // alterar a idade do estudante
            controller.AtualizarDetalhesEstudante("João", 50);

            // Exibição dos detalhes do estudante através do controlador
            controller.ExibirDetalhesEstudante("João");

            // ler dados de um novo estudante
            int novo = controller.LerDadosEstudante();
            
            // verificar se foi adicionado e mostrar os detalhes do novo estudante
            if (novo > 0)
            {
                controller.ExibirDetalhesEstudante(novo);
            }
            
            // exibir lista de estudantes
            controller.ExibirListaEstudantes();
        }
    }
}