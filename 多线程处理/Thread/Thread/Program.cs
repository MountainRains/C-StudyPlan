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
            ThreadStart threadStart = DoWork;
            //Thread thread = new Thread(threadStart);
            Thread thread = new Thread(DoWork);
            thread.Start();
            //thread.Join();
            for (int i = 0; i < Repetitions; i++)
            {
                Console.Write("-");
            }
            thread.Join();
        }

        private static void DoWork()
        {
            for(int count =0; count < Repetitions; count++)
            {
                Console.Write('+');
            }
        }
    }
}
