using System;

namespace FabricaBrinquedos
{
    public class BrinquedoException: ApplicationException
    {
        public BrinquedoException(string txt) : base(txt) { }
    }
    
    public abstract class Brinquedo
    {
        public abstract void Mover();
    }

    public class UrsoPelucia : Brinquedo
    {
        public override void Mover()
        {
            Console.WriteLine("O urso de pelúcia está a mexer-se.");
        }
    }

    public class CarroControleRemoto : Brinquedo
    {
        public override void Mover()
        {
            Console.WriteLine("O carro de controle remoto está a acelerar.");
        }
    }

    public class Boneca : Brinquedo
    {
        public override void Mover()
        {
            Console.WriteLine("A boneca está a dançar.");
        }
    }

    public class FabricaBrinquedos
    {
        public Brinquedo CriarBrinquedo(string tipo)
        {
            switch (tipo)
            {
                case "UrsoPelucia":
                    return new UrsoPelucia();
                case "CarroControleRemoto":
                    return new CarroControleRemoto();
                case "Boneca":
                    return new Boneca();
                default:
                    throw new BrinquedoException("Tipo de brinquedo inválido nesta fábrica.");
            }
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            FabricaBrinquedos fabrica = new FabricaBrinquedos();

            Brinquedo urso = fabrica.CriarBrinquedo("UrsoPelucia");
            urso.Mover();

            Brinquedo carro = fabrica.CriarBrinquedo("CarroControleRemoto");
            carro.Mover();

            Brinquedo boneca = fabrica.CriarBrinquedo("Boneca");
            boneca.Mover();
        }
    }
}
