using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Run(() => Show());
            Task t2 = Task.Run(() => Print());
            Task.WaitAll(t1, t2);
            Console.ReadKey();
        }
        static async void Show()
        {
            await Task.Delay(100);
            Console.WriteLine($"Show function");
        }
        static async void Print()
        {
            await Task.Delay(100);
            Console.WriteLine($"Print function");
        }
    }
}
