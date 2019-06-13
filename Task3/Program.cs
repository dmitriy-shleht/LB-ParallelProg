using System;
using System.Numerics;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {           
            var list = Enumerable.Range(0, 5000).ToList();
            var result = new List<BigInteger>();

            var sw = Stopwatch.StartNew();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(Factorial(i));
            }
            sw.Stop();
            
            Console.WriteLine($"выполнялся:{sw.ElapsedMilliseconds}ms, кол-во обработанных элементов:{result.Count}");
            
            result.Clear();
            
            /////////////////////////////////////////////////////////////
            
            var sw2 = Stopwatch.StartNew();
            Parallel.ForEach(list, x => 
            {
                result.Add(Factorial(x));
            });
            sw2.Stop();

            Console.WriteLine($"выполнялся:{sw2.ElapsedMilliseconds}ms, кол-во обработанных элементов:{result.Count}");
        }

        static BigInteger Factorial(int number)
        {
            var fact = new BigInteger(1);
            for (var i = 1; i <= number; i++)
            {
                fact *= i;
            }

            return fact;
        }
    }
}
