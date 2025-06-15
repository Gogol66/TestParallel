using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            var number = Enumerable.Range(1, 10);
            Parallel.For(1, 10, i =>
             {
                 Console.WriteLine($"Task {i} running on thread {Thread.CurrentThread.ManagedThreadId}");
             });
            Parallel.ForEach(number, i =>
            {
                Console.WriteLine($"Task {i} running on thread {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.ReadKey();
        }
        static async Task Show()
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
