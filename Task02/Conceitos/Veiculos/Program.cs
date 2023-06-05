using System;

namespace Veiculos
{
    public abstract class Veiculo
    {
        public int Rodas { get; set; }
        public abstract void Mover();

        public void MostrarDetalhes()
        {
            Console.WriteLine($"Este veículo possui {Rodas} rodas.");
        }
    }

    public class Carro : Veiculo
    {
        public override void Mover()
        {
            Console.WriteLine("O carro está a mover-se.");
        }
    }

    public class Moto : Veiculo
    {
        public override void Mover()
        {
            Console.WriteLine("A moto está a mover-se.");
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Veiculo carro = new Carro();
            carro.Rodas = 4;
            carro.Mover();
            carro.MostrarDetalhes();

            Veiculo moto = new Moto();
            moto.Rodas = 2;
            moto.Mover();
            moto.MostrarDetalhes();
        }
    }
}