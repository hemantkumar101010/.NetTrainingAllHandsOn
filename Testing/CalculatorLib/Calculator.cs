using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    public class Calculator : ICalculator
    {
       public  int Add(int num1, int num2)
        {
            return num1 + num2; 
        }
        public int Substract(int num1, int num2)
        {
            return (num2 - num1);
        }
        public int Multiply(int num1, int num2)
        {
            return num1* num2;  
        }
        public int Divide(int num1, int num2)
        {
            return num1 / num2;
        }

        public static int mod(int num1,int num2)
        {
            return num2 % num1;
        }
    }
}
