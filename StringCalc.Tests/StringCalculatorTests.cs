namespace StringCalc.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Should_CalculateSimpleExpression()
        {
            
            var calculator = new StringCalculator();
            var expression = "2 + 3";

          
            var result = calculator.Calculate(expression);

           
            Assert.Equal(5, result);
        }

        [Fact]
        public void Should_CalculateExpressionWithParentheses()
        {
         
            var calculator = new StringCalculator();
            var expression = "2 * (3 + 4)";

           
            var result = calculator.Calculate(expression);

            
            Assert.Equal(14, result);
        }

        [Fact]
        public void Should_CalculateComplexExpression()
        {
          
            var calculator = new StringCalculator();
            var expression = "2 + 3 * 4 - 5 / 2";

           
            var result = calculator.Calculate(expression);

         
            Assert.Equal(11.5, result);
        }

        [Fact]
        public void Should_HandleNegativeNumbers()
        {
       
            var calculator = new StringCalculator();
            var expression = "-2 + 3";

         
            var result = calculator.Calculate(expression);

       
            Assert.Equal(1, result);
        }

        [Fact]
        public void Should_HandleDecimalNumbers()
        {
          
            var calculator = new StringCalculator();
            var expression = "3.5 * 2";

          
            var result = calculator.Calculate(expression);

    
            Assert.Equal(7, result);
        }

        [Fact]
        public void Should_HandleDivisionByZero()
        {
            // Arrange
            var calculator = new StringCalculator();
            var expression = "10 / 0";

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Calculate(expression));
        }

        [Fact]
        public void Should_ThrowExceptionForInvalidExpression()
        {
            // Arrange
            var calculator = new StringCalculator();
            var expression = "2 + + 3";

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => calculator.Calculate(expression));
        }

        [Fact]
        public void Should_ThrowExceptionForUnbalancedParentheses()
        {
            // Arrange
            var calculator = new StringCalculator();
            var expression = "(2 + 3";

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => calculator.Calculate(expression));
        }

        [Fact]
        public async Task Should_CalculateExpressionAsynchronously()
        {
            // Arrange
            var calculator = new StringCalculator();
            var expression = "2 * (3 + 4)";

            // Act
            var result = await calculator.CalculateAsync(expression);

            // Assert
            Assert.Equal(14, result);
        }

        [Fact]
        public void Should_HandleSingleNumber()
        {
            // Arrange
            var calculator = new StringCalculator();
            var expression = "42";

            // Act
            var result = calculator.Calculate(expression);

            // Assert
            Assert.Equal(42, result);
        }

        [Fact]
        public void Should_HandleExpressionEndingWithOperator()
        {
            // Arrange
            var calculator = new StringCalculator();
            var expression = "2 + 3 +";

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => calculator.Calculate(expression));
            Assert.Equal("Выражение заканчивается оператором.", ex.Message);
        }

       

        [Fact]
        public void Should_HandleUnknownOperator()
        {
           
            var calculator = new StringCalculator();
            var expression = "2 ^ 3";

           
            var ex = Assert.Throws<InvalidOperationException>(() => calculator.Calculate(expression));
            Assert.Equal("Неизвестный символ: ^", ex.Message);
        }
    }
}