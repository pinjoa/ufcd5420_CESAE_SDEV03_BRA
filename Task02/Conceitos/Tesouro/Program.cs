using System;

namespace Tesouro
{
    public class Tesouro
    {
        private static Tesouro instancia;
    
        private Tesouro()
        {
            Console.WriteLine("Tesouro criado!");
        }
    
        public static Tesouro Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Tesouro();
                }
                return instancia;
            }
        }
    
        public void Guardar()
        {
            Console.WriteLine("O tesouro está a ser guardado com segurança!");
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Tesouro t1 = Tesouro.Instancia;
            t1.Guardar();

            Tesouro t2 = Tesouro.Instancia;
            t2.Guardar();
        
            Console.WriteLine(t1 == t2); // True, pois t1 e t2 referenciam a mesma instância
            Console.WriteLine(ReferenceEquals(t1, t2));
            

        }
    }
}