﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace StringCalc
{
    public class Tokenizer
    {
        public List<string> Tokenize(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new InvalidOperationException("Выражение не может быть пустым.");
            }

            var tokens = new List<string>();
            var currentToken = string.Empty;
            char? previousChar = null;

            for (int i = 0; i < expression.Length; i++)
            {
                var ch = expression[i];

                if (char.IsWhiteSpace(ch))
                {
                    if (!string.IsNullOrEmpty(currentToken))
                    {
                        tokens.Add(currentToken);
                        currentToken = string.Empty;
                    }
                    previousChar = ch;
                    continue;
                }

                if (char.IsDigit(ch) || ch == '.')
                {
                    
                    if (!string.IsNullOrEmpty(currentToken))
                    {
                      
                        currentToken += ch;
                    }
                    else
                    {
                        if (NeedInsertMultiplication(tokens, ch))
                        {
                            tokens.Add("*");
                        }
                        currentToken += ch;
                    }
                }
                else if (IsOperator(ch) || ch == '(' || ch == ')')
                {
                    if (!string.IsNullOrEmpty(currentToken))
                    {
                        tokens.Add(currentToken);
                        currentToken = string.Empty;
                    }

                    
                    if (NeedInsertMultiplication(tokens, ch))
                    {
                        tokens.Add("*");
                    }

                    tokens.Add(ch.ToString());
                }
                else
                {
                    throw new InvalidOperationException($"Неизвестный символ: {ch}");
                }

                previousChar = ch;
            }

            if (!string.IsNullOrEmpty(currentToken))
            {
                tokens.Add(currentToken);
            }

            return tokens;
        }

        private bool IsOperator(char ch)
        {
            return ch == '+' || ch == '-' || ch == '*' || ch == '/';
        }

        private bool NeedInsertMultiplication(List<string> tokens, char currentChar)
        {
            if (tokens.Count == 0)
                return false;

            var lastToken = tokens[^1];

            bool lastTokenIsNumberOrClosingParenthesis = IsNumber(lastToken) || lastToken == ")";
            bool currentCharIsOpeningParenthesisOrNumber = currentChar == '(' || char.IsDigit(currentChar);

            return lastTokenIsNumberOrClosingParenthesis && currentCharIsOpeningParenthesisOrNumber;
        }

        private bool IsNumber(string token)
        {
            return double.TryParse(token, NumberStyles.Number, CultureInfo.InvariantCulture, out _);
        }
    }
}
