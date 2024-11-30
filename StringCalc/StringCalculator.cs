using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalc
{
    public class StringCalculator
    {
        public double Calculate(string expression)
        {
            var tokens = expression.Split(' ');

            if (tokens.Length != 3)
            {
                throw new InvalidOperationException("Некорректное выражение.");
            }

            var num1 = double.Parse(tokens[0]);
            var num2 = double.Parse(tokens[2]);
            var operation = tokens[1];

            return operation switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Деление на ноль."),
                _ => throw new InvalidOperationException($"Неизвестная операция: {operation}")
            };
        }

        public async Task<double> CalculateAsync(string expression)
        {
            return await Task.Run(() => Calculate(expression));
        }
    }
}

