using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class Calculator : IObservable
    {
        public string equation;
        private List<IObserver> _observers;
        public string result;

        public Calculator()
        {
            _observers = new List<IObserver>() {
                new Brackets(), new Multiplication(), new Division(), new Subtraction(), new Addition() };
        }
        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }
        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(ref this.equation);
            }
        }

        public string Calculate(string toCalculate)
        {
           this.equation = toCalculate;
           Notify();
           double resultEquation = 0;
            try
            {
                if (Double.TryParse(this.equation, out resultEquation))
                {
                    return this.result = resultEquation.ToString();
                }
                else
                {
                    return this.result = this.equation + " (Incorect equation)";
                }
            }
            catch
            {
                return this.result = this.equation + " (Incorect equation)";
            }
        }

        public List<string> Calculate(List<string> toCalculate)
        {
            List<string> toReturn = new List<string>();
            foreach(var str in toCalculate)
            {
                 toReturn.Add(Calculate(str));
            }

            return toReturn;
        }
    }
}

