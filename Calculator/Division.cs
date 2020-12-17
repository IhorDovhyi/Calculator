using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Division : IObserver
    {
        public void Update(ref string subject)
        {
            string pattern = @"\-?\d+[\,\.]?\d*\/\d+[\,\.]?\d*";
            Regex regex = new Regex(pattern);
            while (regex.IsMatch(subject))
            {
                string matchStr = "";
                string[] stringsNumbToDiv;
                MatchCollection matchesDiv = regex.Matches(subject);
                foreach (var div in matchesDiv)
                {
                        matchStr = div.ToString();
                        stringsNumbToDiv = regex.Match(subject).ToString().Split('/');
                        double toRerurn = 0;
                        if (((Convert.ToDouble((stringsNumbToDiv[1].Replace('.', ','))) != 0)))
                        {
                            toRerurn = Convert.ToDouble((stringsNumbToDiv[0].Replace('.', ','))) / Convert.ToDouble((stringsNumbToDiv[1].Replace('.', ',')));
                            subject = subject.Replace(matchStr, toRerurn.ToString());
                        }
                        else
                        {
                            subject = "Error. Division by 0";
                        }
                }
            }
        }
    }
}
