using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            var source = new CancellationTokenSource();
            var token = source.Token;
            
            var taskMonitor = Task.Factory.StartNew(() =>
            {
                for (Console.CursorLeft = 0; !token.IsCancellationRequested; Console.CursorLeft+=2)
                {
                    Thread.Sleep(600);

                    if (Console.CursorLeft >= 28)
                        Console.CursorLeft = 13;

                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                    Console.Write($"{cpu.NextValue():00}");
                }
            }, token);
            
            
            for (int i = 1; i <= 4; i++)
            {
                RunOneThread(i);
                RunParallel(i);		
            }

            source.Cancel();
        }

        static void RunOneThread(int count)
        {
            Console.Write("Загрузка CPU:");
            
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                Factorial();
            }          
            sw.Stop();

            Console.CursorLeft = 28;
            Console.WriteLine($"| выполнялся:{sw.ElapsedMilliseconds}ms | кол-во выполнений:{count} | параллельно:НЕТ");
            Console.CursorLeft = 0;
        }

        static void RunParallel(int count)
        {
            var tasks = new List<Thread>();

            for (int i = 0; i < count; i++)
            {
                tasks.Add(new Thread(Factorial));		
            }

            Console.Write("Загрузка CPU:");
            
            var sw = Stopwatch.StartNew();
            tasks.ForEach(x => x.Start());
            
            tasks.ForEach(x =>
            {
                if (x.IsAlive)
                    x.Join();
            });

            sw.Stop();
            
            Console.CursorLeft = 28;
            Console.WriteLine($"| выполнялся:{sw.ElapsedMilliseconds}ms | кол-во выполнений:{count} | параллельно:ДА");
            Console.CursorLeft = 0;
        }

        static void Factorial()
        {
            var f = new BigInteger(1);
            for (var i = 1; i <= 110000; i++)
            {
                f *= i;
            }
        }
    }
}
