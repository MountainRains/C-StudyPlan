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
        public const int Repetitions = 10000;
        static void Main(string[] args)
        {
            Task task = Task.Run((Action) DoWork);
            for (int i = 0; i < Repetitions; i++)
            {
                Console.Write("-");
            }
            task.Wait();
        }

        private static void DoWork()
        {
            for(int count =0; count < Repetitions; count++)
            {
                Console.Write("+");
            }
        }
    }
}
