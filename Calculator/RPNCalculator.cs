using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class RPNCalculator
    {
        public static double Calculate(string input)
        {
            String[] translatedInput = TranslateString(input);
            Stack<double> numbers = new Stack<double>();

            Regex numberRegex = new Regex(@"^-?[0-9]+(?:\,[0-9]*)?$");
            foreach (var item in translatedInput)
            {
                if (numberRegex.IsMatch(item))
                {
                    numbers.Push(double.Parse(item));
                    continue;
                }
                else
                {
                    double helper;
                    switch (item)
                    {
                        case "+":
                            numbers.Push(numbers.Pop() + numbers.Pop());
                            break;
                        case "-":
                            helper = numbers.Pop();
                            numbers.Push(numbers.Pop() - helper);
                            break;
                        case "*":
                            numbers.Push(numbers.Pop() * numbers.Pop());
                            break;
                        case "/":
                            helper = numbers.Pop();
                            numbers.Push(numbers.Pop() / helper);
                            break;
                        case "^":
                            helper = numbers.Pop();
                            numbers.Push(Math.Pow(numbers.Pop(), helper));
                            break;
                        case "!":
                            helper = numbers.Pop();
                            double result = 1;
                            for (int i = 1; i <= helper; i++)
                            {
                                result = result * i;
                            }
                            numbers.Push(result);
                            break;
                        case "ln":
                            numbers.Push(Math.Log(numbers.Pop()));
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
            Dictionary<string, int> prededence = new Dictionary<string, int>
            {
                { "ln", 7 },
                { "!", 7 },
                { "^", 6 },
                { "/", 5 },
                { "*", 5 },
                { "+", 4 },
                { "-", 4 },
                { "(", 0 }
            };
            Queue<string> queue = new Queue<string>();
            Stack<string> stack = new Stack<string>();//62*2+(90/3)+5/4

            //const
            input = input.Replace("π", Math.PI.ToString());

            for (int i = 0; i < input.Length; i++)
            {
                var debug = input[i];
                var numberString = String.Empty;
                while (Char.IsNumber(input[i]) || input[i] == 'π' || input[i] == ',')
                {
                    numberString += input[i];
                    if (i == input.Length - 1) 
                    {
                        break;
                    }
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
                if (prededence.ContainsKey(input[i].ToString()) || ((i < input.Length-1) &&prededence.ContainsKey(input[i].ToString() + input[i+1].ToString())))
                {
                    while (stack.Any() && prededence.Where(x => x.Key == input[i].ToString()).First().Value <= prededence.Where(x => x.Key.ToString() == stack.Peek()).First().Value)
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Push(prededence.ContainsKey(input[i].ToString() + input[i + 1].ToString()) ? input[i].ToString() + input[i + 1].ToString() : input[i].ToString());
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

