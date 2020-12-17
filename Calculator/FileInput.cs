using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calculator
{
    public class FileInput : IRepository
    {
        string pathToFile;
        List<string> listToWork = new List<string>();
        public FileInput(string pathToFile)
        {
            this.pathToFile = pathToFile;
        }

        public void Set(List<string> result)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(pathToFile, false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < listToWork.Count; i++)
                    {
                        sw.WriteLine($"{listToWork[i]} = {result[i]}");
                    }
                }
                Console.WriteLine($"The completed task is - {pathToFile}");
            }
            catch
            {
                Console.WriteLine("Error working with file");
            }
        }
        public List<string> Get()
        {
            using (StreamReader sr = new StreamReader(pathToFile))
            {
                string line;
                try
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (!String.IsNullOrEmpty(line))
                        {
                            listToWork.Add(line);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Error working with file");
                }
            }

            return listToWork;
        }
    }
}
