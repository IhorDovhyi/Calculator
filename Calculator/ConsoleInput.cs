using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Calculator
{
    public class ConsoleInput : IRepository
    {
        List<string> userInput = new List<string>();
        public ConsoleInput(string userInput)
        {
             this.userInput.Add(userInput);
        }
        public List<string> Get()
        {
            return this.userInput;
        }

        public void Set(List<string> result)
        {
            for(int i = 0; i < userInput.Count; i++)
            {
                Console.WriteLine($"{userInput[i] + " = " + result[i]}");
            }
        }
    }
}
