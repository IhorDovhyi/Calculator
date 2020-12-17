using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calculator
{
    public class RepositoryFactory
    {
        string userString;
        FileInfo fileInfo;
        public RepositoryFactory(string stringTouse)
        {
            userString = stringTouse;
        }
        bool IsExist()
        {
            fileInfo = new FileInfo(this.userString);
            return fileInfo.Exists;
        }
        bool IsTXT()
        {
            fileInfo = new FileInfo(this.userString);
            if (".txt" == fileInfo.Extension)
            {
                return true;
            }
            else
                return false;
        }
        public IRepository Repository()
        {
            if (IsTXT() && IsExist())
            {
                IRepository fileInput = new FileInput(this.userString);
                return fileInput;
            }
            else
            {
                IRepository consoleInput = new ConsoleInput(this.userString);
                return consoleInput;
            }
        }
    }
}
