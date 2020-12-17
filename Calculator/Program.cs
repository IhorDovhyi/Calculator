using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the equation or path to the file with equations");
            var userInput = Console.ReadLine();
            var repositoryFactory = new RepositoryFactory(userInput);
            var repository = repositoryFactory.Repository();
            var calculator = new Calculator();
            var result = calculator.Calculate(repository.Get());
            repository.Set(result);
        }
    }
}

