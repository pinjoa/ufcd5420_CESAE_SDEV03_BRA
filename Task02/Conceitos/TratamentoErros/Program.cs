using System;

namespace TratamentoErros
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //Console.WriteLine(int.Parse("produzir um erro!"));
                var rand = new Random();
                if (rand.Next(10, 30) != 31)
                {
                    throw new MyException("Wrong number!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}