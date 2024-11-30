using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StringCalc
{
    public class StringCalculator
    {
        private readonly Tokenizer _tokenizer;
        private readonly PostfixConverter _postfixConverter;
        private readonly PostfixEvaluator _postfixEvaluator;

        public StringCalculator()
        {
            _tokenizer = new Tokenizer();
            _postfixConverter = new PostfixConverter();
            _postfixEvaluator = new PostfixEvaluator();
        }

        public double Calculate(string expression)
        {
            var tokens = _tokenizer.Tokenize(expression);
            ValidateTokens(tokens);

            if (tokens.Count == 3)
            {
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

            
            var postfix = _postfixConverter.ConvertToPostfix(tokens);
            return _postfixEvaluator.Evaluate(postfix);
        }

        public async Task<double> CalculateAsync(string expression)
        {
            return await Task.Run(() => Calculate(expression));
        }

        private void ValidateTokens(List<string> tokens)
        {
            int parenthesesBalance = 0;
            bool expectOperand = true;

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                if (token == "(")
                {
                    parenthesesBalance++;
                    expectOperand = true;
                    continue;
                }

                if (token == ")")
                {
                    parenthesesBalance--;
                    if (parenthesesBalance < 0)
                    {
                        throw new InvalidOperationException("Несбалансированные скобки.");
                    }
                    expectOperand = false;
                    continue;
                }

                if (IsOperator(token))
                {
                    if (expectOperand)
                    {
                        if (token == "-" && (i == 0 || tokens[i - 1] == "(" || IsOperator(tokens[i - 1])))
                        {
                            // Отрицательное число, следующий токен должен быть числом
                            expectOperand = true;
                        }
                        else
                        {
                            throw new InvalidOperationException("Оператор встречен без числа перед ним.");
                        }
                    }
                    else
                    {
                        expectOperand = true;
                    }
                }
                else if (IsNumber(token))
                {
                    if (!expectOperand)
                    {
                        throw new InvalidOperationException("Два числа подряд без оператора.");
                    }
                    expectOperand = false;
                }
                else
                {
                    throw new InvalidOperationException($"Неизвестный токен: {token}");
                }
            }

            if (parenthesesBalance != 0)
            {
                throw new InvalidOperationException("Несбалансированные скобки.");
            }

            if (expectOperand)
            {
                throw new InvalidOperationException("Выражение заканчивается оператором.");
            }
        }

        private bool IsOperator(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }

        private bool IsNumber(string token)
        {
            return double.TryParse(token, out _);
        }
    }
}