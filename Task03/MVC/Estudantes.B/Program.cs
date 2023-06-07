using Estudantes.B.Controller;
using Estudantes.B.Model;
using Estudantes.B.View;

namespace Estudantes.B
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            EstudanteServico servico = new EstudanteServico();
            EstudanteView view = new EstudanteView();
            EstudanteController controller = new EstudanteController(servico, view);

            controller.ExibirDetalhesEstudante(1);
        }
    }
}