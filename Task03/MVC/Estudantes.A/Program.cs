using System;

namespace Estudantes.A
{
    // Modelo (Model)
    public class Estudante
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }

    // Visualizador (View)
    public class EstudanteView
    {
        public void ExibirDetalhesEstudante(string nome, int idade)
        {
            Console.WriteLine("Detalhes do Estudante:");
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Idade: " + idade);
        }
    }

    // Controlador (Controller)
    public class EstudanteController
    {
        private Estudante _estudante;
        private EstudanteView _view;

        public EstudanteController(Estudante estudante, EstudanteView view)
        {
            _estudante = estudante;
            _view = view;
        }

        public void AtualizarDetalhesEstudante(string nome, int idade)
        {
            _estudante.Nome = nome;
            _estudante.Idade = idade;
        }

        public void ExibirDetalhesEstudante()
        {
            _view.ExibirDetalhesEstudante(_estudante.Nome, _estudante.Idade);
        }
    }

    // Exemplo de uso
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Criação do modelo (Model)
            Estudante estudante = new Estudante();

            // Criação da visualização (View)
            EstudanteView view = new EstudanteView();

            // Criação do controlador (Controller)
            EstudanteController controller = new EstudanteController(estudante, view);

            // Atualização dos detalhes do estudante através do controlador
            controller.AtualizarDetalhesEstudante("João", 25);

            // Exibição dos detalhes do estudante através do controlador
            controller.ExibirDetalhesEstudante();

        }
    }
}