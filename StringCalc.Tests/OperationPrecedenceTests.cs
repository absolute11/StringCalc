using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc.Tests
{
    public class OperationPrecedenceTests
    {
        [Fact]
        public void Should_RespectPrecedenceOfOperations()
        {
            var calculator = new StringCalculator();

          
            var result = calculator.Calculate("2 + 3 * 4");

            Assert.Equal(14, result); 
        }

        [Fact]
        public void Should_RespectPrecedenceOfDivision()
        {
            var calculator = new StringCalculator();

            
            var result = calculator.Calculate("10 - 6 / 2");

            Assert.Equal(7, result); 
        }

        [Fact]
        public void Should_HandleMultipleOperations()
        {
            var calculator = new StringCalculator();

           
            var result = calculator.Calculate("2 + 3 * 4 - 5 / 2");

            Assert.Equal(12.5, result);
        }

        [Fact]
        public void Should_CalculateExpression_WithParentheses()
        {
            var calculator = new StringCalculator();

            
            var result = calculator.Calculate("(2 + 3) * 4");

            Assert.Equal(20, result); 
        }

        [Fact]
        public void Should_HandleNestedParentheses()
        {
            var calculator = new StringCalculator();

          
            var result = calculator.Calculate("2 * (3 + (4 - 1))");

            Assert.Equal(12, result); 
        }
    }
}