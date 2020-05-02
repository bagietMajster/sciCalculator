using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class RPNCalculator
    {
        public static double Calculate(string input)
        {
            Char[] translatedInput = TranslateString(input);

            Stack<double> numbers = new Stack<double>();

            foreach (var item in translatedInput)
            {
                if (Char.IsNumber(item))
                {
                    numbers.Push(double.Parse(item.ToString()));
                }
                else
                {
                    switch (item)
                    {
                        case (char)Operators.Plus:
                            numbers.Push(numbers.Pop() + numbers.Pop());
                            break;
                        case (char)Operators.Minus:
                            numbers.Push(numbers.Pop() - numbers.Pop());
                            break;
                        case (char)Operators.Multiplication:
                            numbers.Push(numbers.Pop() * numbers.Pop());
                            break;
                        case (char)Operators.Division:
                            numbers.Push(1 / (numbers.Pop() / numbers.Pop()));
                            break;
                        default:
                            break;
                    }
                }
            }
            return numbers.Pop();
    }
        public static Char[] TranslateString(string input)
        {
            Dictionary<char, int> prededence = new Dictionary<char, int>
            {
                { '/', 5 },
                { '*', 5 },
                { '+', 4 },
                { '-', 4 },
                { '(', 0 }
            };

            Queue<char> queue = new Queue<char>();
            Stack<char> stack = new Stack<char>();

            foreach (char token in input)
            {
                if ('('.Equals(token))
                {
                    stack.Push(token);
                    continue;
                }
                if (')'.Equals(token))
                {
                    while (!'('.Equals(stack.Peek()))
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Pop();
                    continue;
                }
                if (prededence.ContainsKey(token))
                {
                    while (stack.Any() && prededence.Where(x => x.Key == token).First().Value <= prededence.Where(x => x.Key == stack.Peek()).First().Value)
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Push(token);
                    continue;
                }
                if (Char.IsNumber(token))
                {
                    queue.Enqueue(token);
                    continue;
                }
            }
            while (stack.Any())
            {
                queue.Enqueue(stack.Pop());
            }
            return queue.ToArray();
        }
    }
}

