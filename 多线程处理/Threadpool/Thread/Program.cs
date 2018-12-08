using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Thread_Learn
{
    class Program
    {
        public const int Repetitions = 1000;
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(DoWork, '+'); //使用线程池 easy
            ThreadPool.QueueUserWorkItem(DoWork, '#');
            ThreadPool.QueueUserWorkItem(DoWork, '@');
            for (int i = 0; i < Repetitions; i++)
            {
                Console.Write("-");
            }
            Thread.Sleep(1000);
        }

        private static void DoWork(object state)
        {
            for(int count =0; count < Repetitions; count++)
            {
                Console.Write(state);
            }
        }
    }
}
