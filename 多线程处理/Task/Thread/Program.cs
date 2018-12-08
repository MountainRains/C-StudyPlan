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
        /// <summary>
        /// 延续（术语）
        /// 利用ContinueWith（）方法可以构成任务链，由小任务组合成复杂任务。
        /// antecedent 作为上一个任务结束的标志，只有上一个任务结束下一个任务才可以开始
        /// 绑定在同一个任务之后的 taskB 和 taskC 的调用顺序是异步的，也就是说可能是taskC
        /// 先被调用，也可能是taskB 先被调用
        /// </summary>
        public static void Main()
        {
            
            Console.WriteLine("Before");

            Task taskA = Task.Run(
                () => Console.WriteLine("Starting..."))
                .ContinueWith(antecedent =>
                Console.WriteLine("Continuing A ..."));

            Task taskB = taskA.ContinueWith(antecedent =>
                Console.WriteLine("Continuing B ..."));
            Task taskC = taskA.ContinueWith(antecedent =>
                Console.WriteLine("Continuing C ..."));

            Task.WaitAll(taskB, taskC);
            Console.WriteLine("Finished");

        }
    }
}
