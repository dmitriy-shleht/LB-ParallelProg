using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main (string [] args)
		{
			Console.WriteLine($"Main, ThreadId:{Thread.CurrentThread.ManagedThreadId}");

			var t = Task.Factory.StartNew(TaskWork);
			t.Wait();
			
			// имитация коллбэка. Вызов будет в главном потоке!
			Callback();

			Console.ReadLine();
		}

		static void Callback()
		{
			Console.WriteLine($"Callback, ThreadId:{Thread.CurrentThread.ManagedThreadId}");
		}

		static void TaskWork()
		{
			Console.WriteLine($"Task, ThreadId:{Thread.CurrentThread.ManagedThreadId}");
		}
    }
}
