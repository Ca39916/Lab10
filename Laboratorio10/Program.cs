using System;

namespace Laboratorio10
{
    internal class Program
    {
        private static void TrataLimiteSuperior(string msg)
        {
            Console.WriteLine(msg);
        }

        static void Main(string[] args)
        {
            // inicializa o termometro e mostra seu valor
            TermometroLimite term = new TermometroLimite(5);
            Console.WriteLine(term.ToString());
            Console.ReadKey();

            // adiciona um tratador ao evento LimiteSuperiorEvent
            term.LimiteSuperiorEvent += new TermometroLimite.MeuDelegate(TrataLimiteSuperior);
            term.NormalizadoEvent += new TermometroLimite.MeuDelegate(TrataLimiteSuperior);

            // aumentar a temperatura além do limite term.Aumentar(6);
            Console.WriteLine(term.ToString());
            Console.ReadKey();

            Console.WriteLine();
            Console.WriteLine("Aumentando a Temperatura em 6 graus");
            term.Aumentar(6);
            Console.ReadKey();


            Console.WriteLine();
            Console.WriteLine("Diminuindo a Temperatura em 4 graus");
            term.Diminuir(4);
            Console.ReadKey();
               

        }
    }
}
