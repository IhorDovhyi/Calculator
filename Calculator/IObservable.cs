using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public interface IObservable
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
}
