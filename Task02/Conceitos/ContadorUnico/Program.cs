using System;

namespace ContadorUnico
{
    public class Contador
    {
        private static Contador instancia;
        private static int contador = 0;
    
        private Contador()
        {
        }
    
        public static Contador Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Contador();
                }
                return instancia;
            }
        }

        public int Proximo()
        {
            return ++contador;
        }
    
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Contador.Instancia.Proximo());

            }
        }
    }
}