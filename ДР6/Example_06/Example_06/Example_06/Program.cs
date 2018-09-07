using System;
using Example_06.ChainOfResponsibility;

namespace Example_06
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bancomat = new Bancomat();
            Console.WriteLine(bancomat.GetBanknotes("454$"));
            Console.ReadKey();
        }
    }
}
