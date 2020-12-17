using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public interface IRepository
    {
       public void Set(List<string> result);
       public List<string> Get();
    }
}
