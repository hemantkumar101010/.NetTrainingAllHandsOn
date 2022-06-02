using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    public interface ICalculator
    {
        int Add(int num1, int num2);
        int Substract(int num1, int num2);
        int Multiply(int num1, int num2);
        int Divide(int num1, int num2);
    }
}
