using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateHandsOn
{
    public class PrebuildDelegateFunc
    {
        //delegating Sum method
        public static int SumOfWeight(int x, int y, int z)
        {
            return x + y + z;
        }

        //PrebuildDelegateFunc prebuildDelegateFunc = new PrebuildDelegateFunc();


        //using build-in delegate Func (takes some params and return one value)

        public static Func<int, int, int, int> Add;

        //Passing a build-in delegate to a method params.
        public static void AtheletePerformance(string name, Func<int, int, int, int> Add)
        {
            int totalWeight = Add(100,70,55);
            Console.WriteLine($"{name} lifted {totalWeight}Kg weight in all categery :)");
        }

    }
}
