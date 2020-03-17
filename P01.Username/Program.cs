using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace P01.Username
{
    class Program
    {
        static void Main()
        {
            string username = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Sign up")
                {
                    break;
                }
                string[] cmdCollection = input.Split();
                string cmd = cmdCollection[0];

                if (cmd == "Case")
                {
                    string type = cmdCollection[1];
                    if (type == "lower")
                    {
                        username = username.ToLower();
                        Console.WriteLine(username);
                    }
                    else if (type == "upper")
                    {
                        username = username.ToUpper();
                        Console.WriteLine(username);
                    }
                }
                else if (cmd == "Reverse")
                {
                    int startIndex = int.Parse(cmdCollection[1]);
                    int endInex = int.Parse(cmdCollection[2]);
                    if (startIndex >= 0 && endInex < username.Length)
                    {
                        int count = endInex - startIndex + 1;
                        string substr = username.Substring(startIndex, count);
                        string rev = new string(substr.ToCharArray().Reverse().ToArray());
                        Console.WriteLine(rev);
                    }
                }
                else if (cmd == "Cut")
                {
                    string substr = cmdCollection[1];
                    if (username.Contains(substr))
                    {
                        username = username.Replace(substr, string.Empty);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substr}.");
                    }
                }
                else if (cmd == "Replace")
                {
                    char symbolToReplace = char.Parse(cmdCollection[1]);
                    username = username.Replace(symbolToReplace, '*');
                    Console.WriteLine(username);
                }
                else if (cmd == "Check")
                {
                    char symbol = char.Parse(cmdCollection[1]);
                    if (username.Contains(symbol))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {symbol}.");
                    }
                }
            }
        }
    }
}
