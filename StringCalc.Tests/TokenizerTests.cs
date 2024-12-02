using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StringCalc.Tests
{
    public class TokenizerTests
    {
        [Fact]
        public void Should_TokenizeSimpleExpression()
        {
          
            var tokenizer = new Tokenizer();
            var expression = "2 + 3";

            
            var tokens = tokenizer.Tokenize(expression);

          
            Assert.Equal(new List<string> { "2", "+", "3" }, tokens);
        }

        [Fact]
        public void Should_HandleWhitespace()
        {
         
            var tokenizer = new Tokenizer();
            var expression = "   2   +   3   ";

     
            var tokens = tokenizer.Tokenize(expression);

       
            Assert.Equal(new List<string> { "2", "+", "3" }, tokens);
        }

        [Fact]
        public void Should_HandleParentheses()
        {
           
            var tokenizer = new Tokenizer();
            var expression = "(2 + 3) * 4";

         
            var tokens = tokenizer.Tokenize(expression);

      
            Assert.Equal(new List<string> { "(", "2", "+", "3", ")", "*", "4" }, tokens);
        }

        [Fact]
        public void Should_InsertMultiplicationBetweenNumberAndParentheses()
        {
          
            var tokenizer = new Tokenizer();
            var expression = "2(3 + 4)";

            
            var tokens = tokenizer.Tokenize(expression);

            
            Assert.Equal(new List<string> { "2", "*", "(", "3", "+", "4", ")" }, tokens);
        }

        [Fact]
        public void Should_InsertMultiplicationBetweenParenthesesAndNumber()
        {
          
            var tokenizer = new Tokenizer();
            var expression = "(2 + 3)4";

        
            var tokens = tokenizer.Tokenize(expression);

          
            Assert.Equal(new List<string> { "(", "2", "+", "3", ")", "*", "4" }, tokens);
        }

        [Fact]
        public void Should_HandleDecimalNumbers()
        {
         
            var tokenizer = new Tokenizer();
            var expression = "3.14 * 2";

           
            var tokens = tokenizer.Tokenize(expression);

          
            Assert.Equal(new List<string> { "3.14", "*", "2" }, tokens);
        }

       

        [Fact]
        public void Should_HandleMultipleOperators()
        {
           
            var tokenizer = new Tokenizer();
            var expression = "2 + 3 * 4 - 5 / 2";

       
            var tokens = tokenizer.Tokenize(expression);

           
            Assert.Equal(new List<string> { "2", "+", "3", "*", "4", "-", "5", "/", "2" }, tokens);
        }

        [Fact]
        public void Should_ThrowExceptionForUnknownSymbol()
        {
          
            var tokenizer = new Tokenizer();
            var expression = "2 + $";

        
            var ex = Assert.Throws<InvalidOperationException>(() => tokenizer.Tokenize(expression));
            Assert.Equal("Неизвестный символ: $", ex.Message);
        }

        [Fact]
        public void Should_ThrowExceptionForEmptyExpression()
        {
            
            var tokenizer = new Tokenizer();
            var expression = " ";

          
            var ex = Assert.Throws<InvalidOperationException>(() => tokenizer.Tokenize(expression));
            Assert.Equal("Выражение не может быть пустым.", ex.Message);
        }
    }
}
