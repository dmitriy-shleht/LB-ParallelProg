using System;
using System.Numerics;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<BigInteger>();
            
            for (int i = 0; i < 5000; i++)
            {
                list.Add(i+1);
            }
            var arr = Enumerable.Range(0, 10000000).ToList();

            // var sw = Stopwatch.StartNew();
            // for (int i = 0; i < list.Count; i++)
            // {
            //     list[i] = list[i].Factorial();
            // }
            // sw.Stop();
            // Console.WriteLine($"выполнялся:{sw.ElapsedMilliseconds}ms");
            var sw = Stopwatch.StartNew();

            var r = Parallel.ForEach(arr, x=> 
            {
                x *= 2;
            });


            // list.AsParallel().ForAll(x = x => ref x = ref 1);
            sw.Stop();
            Console.WriteLine($"выполнялся:{sw.ElapsedMilliseconds}ms");

        }

        static BigInteger Factorial(this BigInteger number)
        {
            BigInteger fact = 1;
            for (var i = 1; i <= number; i++)
            {
                fact *= i;
            }

            return fact;
        }
    }

    class Name
    {
        
    }
}
