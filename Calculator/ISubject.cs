﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
}
