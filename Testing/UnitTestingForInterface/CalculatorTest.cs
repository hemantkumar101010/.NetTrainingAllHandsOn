using CalculatorLib;
using Moq;

namespace UnitTestingForFunctionsNInterface
{
    public class CalculatorTest
    {
        //Testing interfaces
        [Fact]
        public void CalculatorAddFunctionTest()
        {
            //var calculator = new ICalculator();
            //Assert.Equal(4, calculator.Add(2, 2));

            var calculator = new Mock<ICalculator>();
            calculator.Setup(obj => obj.Add(2, 2)).Returns(4);//setup, fakedata, tempdata
            Assert.Equal(4, calculator.Object.Add(2, 2));
        }
        [Fact]
        public void CalculatorSubstractFunctionTest()
        {
            //var calculator = new ICalculator();
            //Assert.Equal(21, calculator.Substract(1, 22));

            var calculator = new Mock<ICalculator>();
            calculator.Setup(obj => obj.Substract(1, 22)).Returns(21);//setup, fakedata, tempdata
            Assert.Equal(21, calculator.Object.Substract(1, 22));
        }

        //Testing a static method
        [Fact]
        public static void CalculatorModFunctionTest()
        {
            int num1 = 3;
            int num2 = 97;
            var result = Calculator.mod(num1, num2);
            Assert.Equal(1, result); 

        }
    }
}