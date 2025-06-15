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
            for (int i = 0; i < 20; i++)
                ThreadPool.QueueUserWorkItem(WorkItem, i);
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
        static void WorkItem(object state)
        {
            Console.WriteLine($"Task {state} running on thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
