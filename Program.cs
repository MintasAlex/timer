using System;
using System.Diagnostics;
using System.Threading;

namespace TimeCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            Stopwatch stopWatch= timer.StartTimer();

            string initTime = "2020-07-24T13:30:19Z";

            bool b = true;
            do
            {
                Console.WriteLine("a - Afiseaza timpul cu text");
                Console.WriteLine("b - Afiseaza milisecundele de la creearea instantei");
                Console.WriteLine("x - Iesire");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "a":
                        Console.WriteLine("\n\n\n");
                        timer.WriteLineWithTimer("ana are mere \n si mara are mere", timer.GetCurrentTime(stopWatch, initTime));
                        Console.WriteLine("\n\n\n");
                        break;

                    case "b":
                        Console.WriteLine("\n\n\n");
                        Console.WriteLine(timer.ElapsedMillisecondsSinceInitialization(stopWatch));
                        Console.WriteLine("\n\n\n");
                        break;

                    case "x":
                    default:
                        b = false;
                        break;
                }

            } while (b == true);

          
        }

        
    }
}
