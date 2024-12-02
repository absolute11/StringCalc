using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc.Tests
{
    public class PostfixConverterTests
    {
        [Fact]
        public void Should_ConvertSimpleExpressionToPostfix()
        {
            
            var converter = new PostfixConverter();
            var tokens = new List<string> { "2", "+", "3" };

         
            var result = converter.ConvertToPostfix(tokens);

          
            Assert.Equal(new List<string> { "2", "3", "+" }, result);
        }

        [Fact]
        public void Should_ConvertExpressionWithPrecedenceToPostfix()
        {
           
            var converter = new PostfixConverter();
            var tokens = new List<string> { "2", "+", "3", "*", "4" };

        
            var result = converter.ConvertToPostfix(tokens);

         
            Assert.Equal(new List<string> { "2", "3", "4", "*", "+" }, result);
        }

        [Fact]
        public void Should_ConvertExpressionWithParenthesesToPostfix()
        {
         
            var converter = new PostfixConverter();
            var tokens = new List<string> { "(", "2", "+", "3", ")", "*", "4" };

          
            var result = converter.ConvertToPostfix(tokens);

           
            Assert.Equal(new List<string> { "2", "3", "+", "4", "*" }, result);
        }

        [Fact]
        public void Should_ThrowExceptionForUnbalancedParentheses()
        {
           
            var converter = new PostfixConverter();
            var tokens = new List<string> { "(", "2", "+", "3", "*", "4" };

           
            Assert.Throws<InvalidOperationException>(() => converter.ConvertToPostfix(tokens));
        }

        [Fact]
        public void Should_ConvertComplexExpressionToPostfix()
        {
            
            var converter = new PostfixConverter();
            var tokens = new List<string> { "2", "*", "(", "3", "+", "4", "*", "(", "5", "-", "1", ")", ")" };

            
            var result = converter.ConvertToPostfix(tokens);

          
            Assert.Equal(new List<string> { "2", "3", "4", "5", "1", "-", "*", "+", "*" }, result);
        }

        [Fact]
        public void Should_HandleSingleNumber()
        {
            
            var converter = new PostfixConverter();
            var tokens = new List<string> { "42" };

           
            var result = converter.ConvertToPostfix(tokens);

           
            Assert.Equal(new List<string> { "42" }, result);
        }

        [Fact]
        public void Should_ThrowExceptionForUnknownToken()
        {
            
            var converter = new PostfixConverter();
            var tokens = new List<string> { "2", "?", "3" };

           
            var ex = Assert.Throws<InvalidOperationException>(() => converter.ConvertToPostfix(tokens));
            Assert.Equal("Неизвестный токен: ?", ex.Message);
        }
    }
}