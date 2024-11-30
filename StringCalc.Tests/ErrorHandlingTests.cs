using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc.Tests
{
    public class ErrorHandlingTests
    {
        [Fact]
        public void Should_ThrowException_For_InvalidExpression()
        {
            var calculator = new StringCalculator();

            Assert.Throws<InvalidOperationException>(() => calculator.Calculate("2 + + 3"));
        }

        [Fact]
        public void Should_ThrowException_For_UnbalancedParentheses()
        {
            var calculator = new StringCalculator();

            Assert.Throws<InvalidOperationException>(() => calculator.Calculate("(2 + 3 * 4"));
        }
        [Fact]
        public void Should_ThrowException_For_DivisionByZero()
        {
            var calculator = new StringCalculator();

            Assert.Throws<DivideByZeroException>(() => calculator.Calculate("10 / 0"));
        }

        [Fact]
        public void Should_ThrowException_For_EmptyExpression()
        {
            var calculator = new StringCalculator();

            Assert.Throws<InvalidOperationException>(() => calculator.Calculate(""));
        }


        [Fact]
        public void Should_ThrowException_For_UnsupportedOperation()
        {
            var calculator = new StringCalculator();

            Assert.Throws<InvalidOperationException>(() => calculator.Calculate("2 ^ 3"));
        }

    }
}
