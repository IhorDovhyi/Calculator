using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Brackets : IObserver
    {
        string equation;

        private List<IObserver> _observers = new List<IObserver>()
        {new Multiplication(), new Division(), new Subtraction(), new Addition()};
      
        public void Update(ref string subject)
        {
            string pattern = @"\(([\d\.\,\+\-\/\*]+?)\)";
            string old = "";
            Regex regex = new Regex(pattern);
            while (regex.IsMatch(subject))
            {
                MatchCollection matchesBr = regex.Matches(subject);
                foreach (var s in matchesBr)
                {
                    string toChange = subject;
                    old = Convert.ToString(s);
                    this.equation = Convert.ToString(s);
                    this.equation = this.equation.Replace("(", "");
                    this.equation = this.equation.Replace(")", "");
                    Calculator calculator = new Calculator();
                    calculator.Calculate(this.equation);
                    subject = toChange.Replace(old, calculator.equation);
                }
            }
        }
    }
}
