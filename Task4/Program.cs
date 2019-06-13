using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Task4
{
    public class Program
    {
        static void Main(string[] args)
        {
            var source = new CancellationTokenSource();
            var token = source.Token;

            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (!source.IsCancellationRequested)
                {
                    WriteLine($"Задача работает... {i++}");
                    Thread.Sleep(300);
                }
            }, token)
            .ContinueWith(_ => WriteLine("Задача отменена"));


            Thread.Sleep(2000);
            source.Cancel();

            ReadLine();
        }
    }
}
