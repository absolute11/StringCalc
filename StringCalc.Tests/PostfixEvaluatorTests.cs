using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace StringCalc.Tests
{
    public class PostfixEvaluatorTests
    {
        [Fact]
        public void Should_EvaluateSimpleAddition()
        {
           
            var evaluator = new PostfixEvaluator();
            var postfix = new List<string> { "2", "3", "+" };

            
            var result = evaluator.Evaluate(postfix);

          
            Assert.Equal(5, result);
        }

        [Fact]
        public void Should_EvaluateComplexExpression()
        {
         
            var evaluator = new PostfixEvaluator();
            var postfix = new List<string> { "2", "3", "4", "*", "+", "5", "-" };

         
            var result = evaluator.Evaluate(postfix);

          
            Assert.Equal(9, result);
        }

        [Fact]
        public void Should_HandleDivision()
        {
          
            var evaluator = new PostfixEvaluator();
            var postfix = new List<string> { "8", "4", "/" };

       
            var result = evaluator.Evaluate(postfix);

          
            Assert.Equal(2, result);
        }

        [Fact]
        public void Should_HandleDivisionByZero()
        {
           
            var evaluator = new PostfixEvaluator();
            var postfix = new List<string> { "10", "0", "/" };

           
            Assert.Throws<DivideByZeroException>(() => evaluator.Evaluate(postfix));
        }

        [Fact]
        public void Should_HandleInvalidPostfixExpression()
        {
         
            var evaluator = new PostfixEvaluator();
            var postfix = new List<string> { "2", "+" };

           
            Assert.Throws<InvalidOperationException>(() => evaluator.Evaluate(postfix));
        }

        [Fact]
        public void Should_HandleUnknownOperator()
        {
         
            var evaluator = new PostfixEvaluator();
            var postfix = new List<string> { "2", "3", "?" };

         
            var ex = Assert.Throws<InvalidOperationException>(() => evaluator.Evaluate(postfix));
            Assert.Equal("Неизвестная операция: ?", ex.Message);
        }

        [Fact]
        public void Should_HandleSingleNumber()
        {
         
            var evaluator = new PostfixEvaluator();
            var postfix = new List<string> { "42" };

        
            var result = evaluator.Evaluate(postfix);

          
            Assert.Equal(42, result);
        }

        [Fact]
        public void Should_HandleEmptyExpression()
        {
        
            var evaluator = new PostfixEvaluator();
            var postfix = new List<string>();

          
            Assert.Throws<InvalidOperationException>(() => evaluator.Evaluate(postfix));
        }
    }
}

