using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW0206_ThreadSync
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadExecutor threadExecutor = new ThreadExecutor();
            threadExecutor.Add(new Thread(CountTo10));
            threadExecutor.Add(new Thread(PrintHello));
            threadExecutor.Add(new Thread(PrintShlalom));
            //Q1 (not etgar) - threadExecutor.Execute();
            Thread.Sleep(2000);
            threadExecutor.Add(new Thread(CountTo10));
            threadExecutor.Add(new Thread(PrintHello));
            threadExecutor.Add(new Thread(PrintShlalom));
            Console.ReadKey();
        }
        static void CountTo10()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"The number is: {i}");
                Thread.Sleep(10);
            }
        }
        static void PrintHello()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Hello World !");
            }            
        }
        static void PrintShlalom()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Shalom World !");
            }
        }
    }
}
