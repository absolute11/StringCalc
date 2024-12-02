using System.Globalization;

namespace StringCalc
{
    public class PostfixConverter
    {
        private readonly Dictionary<string, int> _precedence = new()
        {
            { "+", 1 },
            { "-", 1 },
            { "*", 2 },
            { "/", 2 },
            { "u-", 3 } // Унарный минус имеет более высокий приоритет
        };

        public List<string> ConvertToPostfix(List<string> tokens)
        {
            var output = new List<string>();
            var operators = new Stack<string>();

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                if (IsNumber(token))
                {
                    HandleNumber(token, output);
                }
                else if (token == "(")
                {
                    HandleOpenParenthesis(operators);
                }
                else if (token == ")")
                {
                    HandleCloseParenthesis(operators, output);
                }
                else if (IsOperator(token))
                {
                    // Проверка на унарный минус
                    if (token == "-" && (i == 0 || tokens[i - 1] == "(" || IsOperator(tokens[i - 1])))
                    {
                        token = "u-"; // Заменяем на унарный минус
                    }
                    HandleOperator(token, operators, output);
                }
                else
                {
                    throw new InvalidOperationException($"Неизвестный токен: {token}");
                }
            }

            while (operators.Count > 0)
            {
                var op = operators.Pop();
                if (op == "(")
                {
                    throw new InvalidOperationException("Несбалансированные скобки.");
                }
                output.Add(op);
            }

            return output;
        }

        private bool IsNumber(string token)
        {
            return double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out _);
        }

        private bool IsOperator(string token)
        {
            return _precedence.ContainsKey(token);
        }

        private void HandleNumber(string token, List<string> output)
        {
            output.Add(token);
        }

        private void HandleOpenParenthesis(Stack<string> operators)
        {
            operators.Push("(");
        }

        private void HandleCloseParenthesis(Stack<string> operators, List<string> output)
        {
            while (operators.Count > 0 && operators.Peek() != "(")
            {
                output.Add(operators.Pop());
            }

            if (operators.Count == 0 || operators.Pop() != "(")
            {
                throw new InvalidOperationException("Несбалансированные скобки.");
            }
        }

        private void HandleOperator(string token, Stack<string> operators, List<string> output)
        {
            while (operators.Count > 0 && IsOperator(operators.Peek()) &&
                   _precedence[operators.Peek()] >= _precedence[token])
            {
                output.Add(operators.Pop());
            }
            operators.Push(token);
        }
    }
}