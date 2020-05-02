using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class RPNCalculator
    {
        public static double Calculate(string input)
        {
            String[] translatedInput = TranslateString(input);

            Stack<double> numbers = new Stack<double>();

            foreach (var item in translatedInput)
            {
                if (item.All(char.IsNumber))
                {
                    numbers.Push(double.Parse(item));
                }
                else
                {
                    switch (item)
                    {
                        case "+":
                            numbers.Push(numbers.Pop() + numbers.Pop());
                            break;
                        case "-":
                            numbers.Push(numbers.Pop() - numbers.Pop());
                            break;
                        case "*":
                            numbers.Push(numbers.Pop() * numbers.Pop());
                            break;
                        case "/":
                            numbers.Push(1 / (numbers.Pop() / numbers.Pop()));
                            break;
                        default:
                            break;
                    }
                }
            }
            return numbers.Pop();
    }

        public static String[] TranslateString(string input)
        {
            Dictionary<char, int> prededence = new Dictionary<char, int>
            {
                { '/', 5 },
                { '*', 5 },
                { '+', 4 },
                { '-', 4 },
                { '(', 0 }
            };
            Queue<string> queue = new Queue<string>();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < input.Length; i++)
            {
                var debug = input[i];
                var numberString = String.Empty;
                while (Char.IsNumber(input[i]))
                {
                    numberString += input[i];
                    i++;
                }
                if(numberString != String.Empty)
                {
                    queue.Enqueue(numberString);
                    numberString = String.Empty;
                }
                if (input[i].Equals('('))
                {
                    stack.Push(input[i].ToString());
                    continue;
                }
                if (input[i].Equals(')')) 
                {
                    while (!"(".Equals(stack.Peek())) //wrzucić to na stacka, czemu to tak się dzieje
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Pop();
                    continue;
                }
                if (prededence.ContainsKey(input[i]))
                {
                    while (stack.Any() && prededence.Where(x => x.Key == input[i]).First().Value <= prededence.Where(x => x.Key.ToString() == stack.Peek()).First().Value)
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Push(input[i].ToString());
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

