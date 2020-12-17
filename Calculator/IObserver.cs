using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public interface IObserver
    {
        void Update(ref string subject);
    }
}
