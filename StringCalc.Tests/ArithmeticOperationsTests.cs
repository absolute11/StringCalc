using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc.Tests
{

    public class ArithmeticOperationsTests
    {
        [Fact]
        public void Should_AddTwoNumbers()
        {
        
            var calculator = new StringCalculator();

            
            var result = calculator.Calculate("2 + 3");

         
            Assert.Equal(5, result);
        }

        [Fact]
        public void Should_SubtractTwoNumbers()
        {
            
            var calculator = new StringCalculator();

           
            var result = calculator.Calculate("7 - 4");

            
            Assert.Equal(3, result);
        }

        [Fact]
        public void Should_MultiplyTwoNumbers()
        {
            
            var calculator = new StringCalculator();

           
            var result = calculator.Calculate("6 * 2");

            
            Assert.Equal(12, result);
        }

        [Fact]
        public void Should_DivideTwoNumbers()
        {
           
            var calculator = new StringCalculator();

            
            var result = calculator.Calculate("8 / 2");

           
            Assert.Equal(4, result);
        }

        [Fact]
        public async Task Should_ThrowException_When_DividingByZero()
        {
            // Arrange
            var calculator = new StringCalculator();

            // Act & Assert
            await Assert.ThrowsAsync<DivideByZeroException>(async () => await calculator.CalculateAsync("10 / 0"));
        }
    }
}
