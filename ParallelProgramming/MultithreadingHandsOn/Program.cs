using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingHandsOn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskParallelExecutions taskParallelExecutions = new TaskParallelExecutions();
            taskParallelExecutions.DisplayCars();

            //creating threads

            //Thread t1 = new Thread(taskParallelExecutions.ShowBuyerReport);
            //Thread t2 = new Thread(taskParallelExecutions.ShowDealerReport);

            //stating threads
           // t1.Start();
            //t2.Start(); 
            
        }
    }
}
